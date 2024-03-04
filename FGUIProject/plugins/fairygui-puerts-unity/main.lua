--FYI: https://github.com/Tencent/xLua/blob/master/Assets/XLua/Doc/XLua_Tutorial_EN.md

local genModelCode = require(PluginPath..'/GenModelCode')
local genHotfixCode = require(PluginPath..'/GenHotfixCode')

function onPublish(handler)
    if not handler.genCode then return end
    handler.genCode = false --prevent default output

    genModelCode(handler)
    genHotfixCode(handler)
end

function onDestroy()
-------do cleanup here-------
end