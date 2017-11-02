import "UnityEngine"
local showText
function main()
    local clickBtn =UnityEngine.GameObject.Find("Canvas/clickBtn"):GetComponent("Button")
    showText =UnityEngine.GameObject.Find("Canvas/showText"):GetComponent("Text")
    clickBtn.onClick.AddListener(clickFun)
end

function clickFun()
    showText.text="测试点击按钮输出文本"
end