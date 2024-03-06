local function FileExists(path)
  local file, err = io.open(path, "r")
  if file then 
      file:close()
    return true
  end

  return false
end

--  根据type获取类型名字
local function GetClassInfo(classes, type)
  for i = 0, classes.Count - 1, 1 do
    local classInfo = classes[i]
    if (classInfo.className == type) then
      return classInfo
    end
  end
  return nil
end

-- 遍历子物体
local function LoopChildProperty(writer, classes, classInfo, varName)
  local members = classInfo.members
  for i = 0, members.Count - 1 do
    local memberInfo = members[i]
    local tempClassInfo = GetClassInfo(classes, memberInfo.type)
    local type = tempClassInfo ~= nil and tempClassInfo.superClassName or memberInfo.type
    local propertName = varName ~= nil and varName .. string.gsub(memberInfo.varName, 'G', '_', 1)  or memberInfo.varName
    writer:writeln('public %s %s { get; set; }',  type, propertName)
    if tempClassInfo ~= nil then
      LoopChildProperty(writer, classes, tempClassInfo, propertName)
    end
  end
end


-- 创建界面名字类
local function CreatePanelNameClass(handler, writer, classes)
  local fullPath = handler.exportCodePath .. '/ModelView/Client/Logic/UI/UIName.cs'
  os.remove(fullPath)
  writer:reset()
  writer:writeln('namespace ET.Client')
  writer:startBlock()
  writer:writeln('public static partial class UIName')
  writer:startBlock()
  local packages = handler.project.allPackages
  local packageCount = packages.Count
  for i = 0, packageCount - 1 do
    local tempPackage = packages[i]
    local packageItems = tempPackage.items
    for j = 0, packageItems.Count - 1, 1 do
      local packageItem = packageItems[j]
      local startIndex, endIndex = string.find(packageItem.name, "UI")
      if (startIndex ~= nil and startIndex == 1) then
        writer:writeln('public const string %s = "%s";', packageItem.name, packageItem.name)
      end
    end
  end
  writer:endBlock()
  writer:endBlock()
  writer:save(fullPath)
end

-- 创建包名类
local function CreatePackageNameClass(handler, writer, classes)
  local fullPath = handler.exportCodePath .. '/ModelView/Client/Logic/UI/UIPackageName.cs'
  os.remove(fullPath)
  writer:reset()
  writer:writeln('namespace ET.Client')
  writer:startBlock()
  writer:writeln('public static partial class UIPackageName')
  writer:startBlock()
  local packages = handler.project.allPackages
  for i = 0, packages.Count - 1 do
    local tempPackage = packages[i]
    writer:writeln('public const string %s = "%s";', tempPackage.name, tempPackage.name)

  end
  writer:endBlock()
  writer:endBlock()
  writer:save(fullPath)
end

-- 创建逻辑类
local function CreateLogincClass(handler, writer, classes, classInfo, exportCodePath, getMemberByName)
  handler:SetupCodeFolder(exportCodePath  .. "/" .. classInfo.className, "ts")

  local fullPath = exportCodePath .. '/' .. classInfo.className .. '/' .. classInfo.className .. 'LogicComponent.cs'
  if FileExists(fullPath) then
    return
  end

  writer:reset()
  writer:writeln('namespace ET.Client')
  writer:startBlock()
  writer:writeln('[ComponentOf(typeof(UI))]')
  writer:writeln('public class %sLogicComponent: Entity, IAwake, IDestroy', classInfo.className)

  writer:startBlock()
  writer:writeln()
  writer:endBlock()
      
  writer:endBlock()
  writer:save(fullPath)
end


-- 创建类
local function CreateComponentClass(handler, writer, classes, classInfo, exportCodePath, getMemberByName)
  -- 只有组件结尾是Panel的才创建
  local startIndex, endIndex = string.find(classInfo.className, "UI")
  if (startIndex == nil or startIndex ~= 1) then
    return
  end

  CreateLogincClass(handler, writer, classes, classInfo, exportCodePath, getMemberByNam)
       
  local fullPath = exportCodePath .. '/' .. "GeneratedCode/" .. classInfo.className .. 'Component.cs';
  -- 如果存在组件类就删除掉这个组件类，重新创建
  os.remove(fullPath)
  writer:reset()
      
  writer:writeln('using FairyGUI;')
  writer:writeln()
      
  writer:writeln('namespace ET.Client')
  writer:startBlock()
      
  writer:writeln('[ComponentOf(typeof(UI))]')
  writer:writeln('public class %sComponent: Entity, IAwake, IDestroy', classInfo.className)
  writer:startBlock()

  LoopChildProperty(writer, classes, classInfo)
      
  writer:endBlock()
      
  writer:endBlock()
        
  writer:save(fullPath)
end

local function genModelCode(handler)
 
    local settings = handler.project:GetSettings("Publish").codeGeneration
    local codePkgName = handler:ToFilename(handler.pkg.name)
    local exportCodePath = handler.exportCodePath .. '/ModelView/Client/Logic/UI/' .. codePkgName
 
    local classes = handler:CollectClasses(settings.ignoreNoname, settings.ignoreNoname, nil)
    handler:SetupCodeFolder(exportCodePath  .. "/GeneratedCode", "ts")

    local getMemberByName = settings.getMemberByName

    local classCnt = classes.Count
 
    local writer = CodeWriter.new()
    for i = 0, classCnt - 1 do
        local classInfo = classes[i]
        CreateComponentClass(handler, writer, classes, classInfo, exportCodePath, getMemberByName);
    end

    CreatePanelNameClass(handler, writer, classes)
    CreatePackageNameClass(handler, writer, classes)
end


return genModelCode