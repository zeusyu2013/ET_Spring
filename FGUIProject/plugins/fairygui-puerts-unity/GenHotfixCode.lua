

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
local function LoopChildProperty(writer, classes, classInfo, varName, getMemberByName)
    local members = classInfo.members
    for i = 0, members.Count - 1 do
        local memberInfo = members[i]
        local tempClassInfo = GetClassInfo(classes, memberInfo.type)
        local type = tempClassInfo ~= nil and tempClassInfo.superClassName or memberInfo.type
        local propertName = varName ~= nil and varName .. string.gsub(memberInfo.varName, 'G', '_', 1) or memberInfo.varName
        local parnetName = varName ~= nil and 'self.' .. varName or 'ui.Component'
        if (memberInfo.group == 0) then -- 常规组件
            if getMemberByName then
                writer:writeln('self.%s = %s.GetChild("%s") as %s;', propertName, parnetName, memberInfo.name, type)
            else
                writer:writeln('self.%s = %s.GetChildAt(%s) as %s;', propertName, parnetName, memberInfo.index, type)
            end
        elseif memberInfo.group == 1 then -- 控制器
            if getMemberByName then
                writer:writeln('self.%s = %s.GetController("%s");', propertName, parnetName, memberInfo.name)
            else
                writer:writeln('self.%s = %s.GetControllerAt(%s);', propertName, parnetName, memberInfo.index)
            end
        else
            if getMemberByName then
                writer:writeln('self.%s = %s.GetTransition("%s") as %s;', propertName, parnetName, memberInfo.name, type)
            else
                writer:writeln('self.%s = %s.GetTransitionAt(%s) as %s;', propertName, parnetName, memberInfo.index, type)
            end
        end

        if tempClassInfo ~= nil then
            LoopChildProperty(writer, classes, tempClassInfo, propertName, getMemberByName)
        end
    end
end


local function LoopChildPropertyEnd(writer, classes, classInfo, varName)
    local members = classInfo.members
    for i = 0, members.Count - 1 do
        local memberInfo = members[i]
        local tempClassInfo = GetClassInfo(classes, memberInfo.type)
        local propertName = varName ~= nil and varName .. string.gsub(memberInfo.varName, 'G', '_', 1) or memberInfo.varName
        writer:writeln('self.%s = null;', propertName)

        if tempClassInfo ~= nil then
            LoopChildPropertyEnd(writer, classes, tempClassInfo, propertName)
        end
    end
end

-- 创建event类
local function CreateEventClass(writer, classes, classInfo, exportCodePath)
    local fullPath = exportCodePath .. '/' .. "GeneratedCode/" .. classInfo.className .. 'EventHandler.cs'
    -- 移除掉原有的类
    os.remove(fullPath)
    writer:reset()

    writer:writeln('using FairyGUI;')
    writer:writeln('namespace ET.Client')
    writer:startBlock()
    writer:writeln('[UIEvent(UIName.%s)]', classInfo.className)
    writer:writeln('public class %s : AUIEvent', classInfo.className .. 'EventHandler')
    writer:startBlock()
  
    writer:writeln('public override async ETTask<UI> OnCreate(UIComponent uiComponent)')
    writer:startBlock()
    writer:writeln('GObject gOject = await uiComponent.LoadUIObject(UIPackageName.%s, UIName.%s);', classInfo.res.owner.name, classInfo.className)
    writer:writeln('if (gOject == null) return null;')
    writer:writeln('UI ui = uiComponent.CreateUI(UIPackageName.%s, UIName.%s);', classInfo.res.owner.name, classInfo.className)
    writer:writeln('ui.Component = gOject as GComponent;')
    writer:writeln('ui.AddComponent<%sComponent>();', classInfo.className)
      
    -- 逻辑类最后添加，防止逻辑类执行，缺少对应脚本
    writer:writeln('ui.AddComponent<%sLogicComponent>();', classInfo.className)
    writer:writeln('return ui;')
    writer:endBlock()

    writer:writeln()
    writer:writeln('public override void OnShow(UIComponent uiComponent, UI ui)')
    writer:startBlock()
    writer:writeln('var logicComponent = ui.GetComponent<%sLogicComponent>();', classInfo.className)
    writer:writeln('logicComponent.OnShow();')
    writer:endBlock()

    writer:writeln()
    writer:writeln('public override void OnHide(UIComponent uiComponent, UI ui)')
    writer:startBlock()
    writer:writeln('var logicComponent = ui.GetComponent<%sLogicComponent>();', classInfo.className)
    writer:writeln('logicComponent.OnHide();')
    writer:endBlock()

    writer:endBlock()
    writer:endBlock()
    writer:save(fullPath)
end
    
-- 创建逻辑System脚本
local function CreateLogicComponentSystemClass(handler, writer, classes, classInfo, exportCodePath)
    handler:SetupCodeFolder(exportCodePath .. '/' .. classInfo.className, "ts")
    local fullPath = exportCodePath .. '/' .. classInfo.className .. '/' .. classInfo.className .. 'LogicComponentSystem.cs';
    if FileExists(fullPath) then
        return
    end
    writer:reset()
    writer:writeln('namespace ET.Client')
    writer:startBlock()
    writer:writeln('[EntitySystemOf(typeof(%sLogicComponent))]', classInfo.className)
    writer:writeln('[FriendOf(typeof(%sLogicComponent))]', classInfo.className)
    writer:writeln('public static partial class %sLogicComponentSystem', classInfo.className)
    writer:startBlock()

    writer:writeln('[EntitySystem]')
    writer:writeln('private static void Awake(this %sLogicComponent self)', classInfo.className)
    writer:startBlock()
    writer:endBlock()

    writer:writeln('[EntitySystem]')
    writer:writeln('private static void Destroy(this %sLogicComponent self)', classInfo.className)
    writer:startBlock()
    writer:endBlock()

    writer:writeln('public static void OnHide(this %sLogicComponent self)', classInfo.className)
    writer:startBlock()
    writer:endBlock()

    writer:writeln()

    writer:writeln('public static void OnShow(this %sLogicComponent self)', classInfo.className)
    writer:startBlock()
    writer:endBlock()

    writer:endBlock()
    writer:endBlock()
    writer:save(fullPath)
end

-- 创建组件类的system脚本
local function CreateComponentSystemClass(handler, writer, classes, classInfo, exportCodePath, getMemberByName)
    -- 只有组件结尾是Panel的才创建
    local startIndex, endIndex = string.find(classInfo.className, "UI")
    if (startIndex == nil or startIndex ~= 1) then
        return
    end

    CreateLogicComponentSystemClass(handler, writer, classes, classInfo, exportCodePath)
    CreateEventClass(writer, classes, classInfo, exportCodePath)

    local fullPath = exportCodePath .. '/' .. "GeneratedCode/"  .. classInfo.className .. 'ComponentSystem.cs';
    os.remove(fullPath)
    writer:reset()

    writer:writeln('using FairyGUI;')
    writer:writeln()
    writer:writeln('namespace ET.Client')
    writer:startBlock()
    
    local className = classInfo.className .. 'Component'
    writer:writeln('[EntitySystemOf(typeof(%s))]', className)
    writer:writeln('[FriendOf(typeof(%s))]', className)
    writer:writeln('public static partial class %sComponentSystem', classInfo.className)
    writer:startBlock()

    writer:writeln('[EntitySystem]')
    writer:writeln('private static void Awake(this %sComponent self)', classInfo.className)
    writer:startBlock()
    writer:writeln('UI ui = self.Parent as UI;')
    LoopChildProperty(writer, classes, classInfo, nil, getMemberByName)
    writer:endBlock()

    writer:writeln('[EntitySystem]')
    writer:writeln('private static void Destroy(this %sComponent self)', classInfo.className)
    writer:startBlock()
    LoopChildPropertyEnd(writer, classes, classInfo, nil)
    writer:endBlock()

    writer:endBlock()
    writer:endBlock()
    writer:save(fullPath)
end


local function genHotfixCode(handler)
    local settings = handler.project:GetSettings("Publish").codeGeneration
    local codePkgName = handler:ToFilename(handler.pkg.name)
    local exportCodePath = handler.exportCodePath .. '/HotfixView/Client/Game/UI/' .. codePkgName 

    local classes = handler:CollectClasses(settings.ignoreNoname, settings.ignoreNoname, nil)
    handler:SetupCodeFolder(exportCodePath .. "/GeneratedCode", "ts")

    local getMemberByName = settings.getMemberByName

    local writer = CodeWriter.new()
    local classCnt = classes.Count
    for i = 0, classCnt - 1 do
        local classInfo = classes[i]
        CreateComponentSystemClass(handler, writer, classes, classInfo, exportCodePath, getMemberByName);
    end
end

return genHotfixCode