import "UnityEngine"

local class ={}
isFirst =true

function main()

  
   local itemdata ={item1=40}
   local canvasTrans =UnityEngine.GameObject.Find("Canvas").transform
   local scrollPanel1 =canvasTrans:Find("CharacterPanel/Right_Panel/WholePanel/ScrollPanel1")
   local scrollPanel2 =canvasTrans:Find("CharacterPanel/Right_Panel/WholePanel/ScrollPanel2")
   local scrollPanel3 =canvasTrans:Find("CharacterPanel/Right_Panel/WholePanel/ScrollPanel3")
   local changeBar =canvasTrans:Find("CharacterPanel/Right_Panel/WholePanel/ChangeBar/Page/Text"):GetComponent(UI.Text)

   local templeftPanel =canvasTrans:Find("CharacterPanel/Right_Panel/LeftPanel")
   local tempmidPanel =canvasTrans:Find("CharacterPanel/Right_Panel/MidPanel")
   local temprightPanel =canvasTrans:Find("CharacterPanel/Right_Panel/RightPanel")
   local leftPanel =templeftPanel:GetComponent(UI.Button)
   local midPanel =tempmidPanel:GetComponent(UI.Button)
   local rightPanel =temprightPanel:GetComponent(UI.Button)

   local leftText=templeftPanel:Find("Title"):GetComponent(UI.Text)
   local midText=tempmidPanel:Find("Title"):GetComponent(UI.Text)
   local rightText=temprightPanel:Find("Title"):GetComponent(UI.Text)

   leftPanel.onClick:AddListener(function()
      scrollPanel1.gameObject:SetActive(true)
      scrollPanel2.gameObject:SetActive(false)
      scrollPanel3.gameObject:SetActive(false)
      leftText.color=Color.white
      midText.color=Color.black
      rightText.color=Color.black
      changeBar.text="1/3"
   end)
   midPanel.onClick:AddListener(function()
      scrollPanel1.gameObject:SetActive(false)
      scrollPanel2.gameObject:SetActive(true)
      scrollPanel3.gameObject:SetActive(false)
      leftText.color=Color.black
      midText.color=Color.white
      rightText.color=Color.black
      changeBar.text="2/3"
   end)
   rightPanel.onClick:AddListener(function()
      scrollPanel1.gameObject:SetActive(false)
      scrollPanel2.gameObject:SetActive(false)
      scrollPanel3.gameObject:SetActive(true)
      leftText.color=Color.black
      midText.color=Color.black
      rightText.color=Color.white
      changeBar.text="3/3"
   end)


   local playBtn=GameObject.Find("Canvas/PlayBtn"):GetComponent(UI.Button) 
   local settingBtn =GameObject.Find("Canvas/SettingBtn"):GetComponent(UI.Button)
   local userBtn =GameObject.Find("Canvas/UserBtn"):GetComponent(UI.Button)

   local closeCBtn =canvasTrans:Find("CharacterPanel/CloseBtn"):GetComponent(UI.Button)
   local closeSBtn =canvasTrans:Find("SettingPanel/CloseBtn"):GetComponent(UI.Button)
   local characterPanel =canvasTrans:Find("CharacterPanel")
   local settingPanel =canvasTrans:Find("SettingPanel")
  
   playBtn.onClick:AddListener(function()
       print("isFirst")
   end)

   settingBtn.onClick:AddListener(function()
       settingPanel.gameObject:SetActive(true)
   end)

   userBtn.onClick:AddListener(function()
       if isFirst==true then      
         characterPanel.gameObject:SetActive(true)
         for i=1,itemdata.item1 do
           local prefab =Resources.Load("Prefabs/item"..math.random(3))--随机生成物品，将其放置在指定位置
           local p = GameObject.Instantiate(prefab,Vector3.zero,Quaternion.identity)
           p.transform:SetParent(GetEmptyGrid())
           p.transform.localPosition = Vector3.zero;
           p.transform.localScale = Vector3.one;
         end
         scrollPanel1.gameObject:SetActive(true)
         scrollPanel2.gameObject:SetActive(false)
         scrollPanel3.gameObject:SetActive(false)

         isFirst=false

       else
         characterPanel.gameObject:SetActive(true)
       end
   end)

   closeCBtn.onClick:AddListener(function()
       characterPanel.gameObject:SetActive(false)
   end)

   closeSBtn.onClick:AddListener(function()
       settingPanel.gameObject:SetActive(false)
   end)
end
--goodArray =GameObject.FindGameObjectsWithTag("Good")


function GetEmptyGrid()
  local goodArray =GameObject.FindGameObjectsWithTag("Good")
  --print(goodArray[1])
  
  for i=1,40 do
    if(goodArray[i].transform.childCount==0) then
      return goodArray[i].transform
    end
  end
  return nil
end


