# AVG Game Project Document







# Player Control

--- player.cs

玩家控制器 玩家活動控制



### 屬性

| 屬性                                         | 作用                                              |
| ------------------------------------------ | ----------------------------------------------- |
| Dictionary<string, Item> allItemDictionary | 存儲所有遊戲中出現的物件種類以及相關信息<string, Item> == <物件名, 屬性> |
| bool freezePlayer                          | 是否凍結玩家, true代表不能移動, false代表可以移動                 |
| Dictionary<string, int> inventory          | 玩家物品欄<string, int> == <持有物品名, 此物品持有數量>          |





### 函數

| 函數      | 傳入值                                                        | 作用                                                                          |
| ------- | ---------------------------------------------------------- | --------------------------------------------------------------------------- |
| getItem | (string name, int number)name是獲取到的物品的id, number是獲取到的此物品的數量 | 給玩家物品, 具體來說是給玩家number個name物品此函數應該從normalItem類的getItem調用, 除非物品不繼承自normalItem |





# Camera Control

-- camCon.cs



攝像頭控制器 存在5個可調用函數和一個屬性



### 函數

| 函數                     | 傳入值                                                                                          | 作用                                                           |
| ---------------------- | -------------------------------------------------------------------------------------------- | ------------------------------------------------------------ |
| void follow            | string -- 攝像頭要跟隨的對象, 必須要是個gameObject的名字                                                      | 令攝像頭跟隨某個腳色 將那個腳色一直處於畫面中心                                     |
| void stopFollow        | null                                                                                         | 停止跟隨某對象 將followSomeone設為false                                |
| void moveCamVertical   | (float y_target, float travelTime)y_target 是攝像頭的目標位置(絕對座標)travelTime 是攝像頭移動到目標位置所花費的時間, 單位是秒 | 將攝像頭在指定時間內垂直移動至目標位置! 盡可能不要將兩個同樣的函數放在一起, 若要實現變速，要另外寫時間控制      |
| void moveCamHorizontal | (float x_target, float travelTime)x_target 是攝像頭的目標位置(絕對座標)travelTime 是攝像頭移動到目標位置所花費的時間, 單位是秒 | 將攝像頭在指定時間內水平移動至目標位置! 盡可能不要將兩個同樣的函數放在一起, 若要實現變速，要另外寫時間控制      |
| void setFreshRate      | float timeSlice -- 攝像頭運動刷新間隔時間                                                               | 設定攝像頭刷新率 -- 具體是指攝像頭每過 timeSlice 秒 就會移動某段距離 預設每0.025f 秒就會移動一次 |





# Inventory UI System.cs

### 屬性

- 注意, 本類的屬性主要是由UI系統內部調用, 裡面數值請務必通過Unity 的GUI介面來修改

| 屬性                      | 作用                                                                                    |
| ----------------------- | ------------------------------------------------------------------------------------- |
| Text showList           | showList是要顯示在 inventory介面上 顯示持有物品的文字 通過語文本連結實現 -- 這一變量與InventoryUISystem下面的Text物件直接關聯 |
| Text selector           | 是用來顯示Inventory介面上的光標 -- 與Inventory下面的selector直接關聯                                     |
| Color panel_Color       | 物品欄的背景顏色                                                                              |
| Color textColor         | 文字的顏色                                                                                 |
| bool inventoryShowState | 當前物品欄的顯示狀態, 預設值是false ! 要開啟物品欄時起不要直接把值設為true, 要調用函數showInventory()                    |



### 函數



//Inventory Panel System

| 函數                       | 傳入值  | 作用                                                       |
| ------------------------ | ---- | -------------------------------------------------------- |
| void packageButtonDown() | null | 調用時相等於按下了一次開啟/關閉 物品欄的按鈕, 若按下時物品欄顯示 則隱藏, 反之若物品欄未顯示，則顯示物品欄 |
| void showInventory()     | null | 顯示物品欄                                                    |
| void hideInventory()     | null | 隱藏物品欄                                                    |

//Selector 

| 函數                               | 傳入值  | 作用                               |
| -------------------------------- | ---- | -------------------------------- |
| void selectorUpMove()            | null | 將Inventory Panel上 選擇物品的光標向上移一個單位 |
| void selectorDownMove()          | null | 將Inventory Panel上 選擇物品的光標向下移一個單位 |
| void showSelectFunctionalPanel() | null | 顯示選擇某個物品時可操作的選項 [!尚未實作]          |





















# Item System

![](https://tcs.teambition.net/storage/111s7ab94ebbbbde22eac1fddd20420690c7?Signature=eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJBcHBJRCI6IjU5Mzc3MGZmODM5NjMyMDAyZTAzNThmMSIsIl9hcHBJZCI6IjU5Mzc3MGZmODM5NjMyMDAyZTAzNThmMSIsIl9vcmdhbml6YXRpb25JZCI6IiIsImV4cCI6MTU5NTYwNzkxNiwiaWF0IjoxNTk1MDAzMTE2LCJyZXNvdXJjZSI6Ii9zdG9yYWdlLzExMXM3YWI5NGViYmJiZGUyMmVhYzFmZGRkMjA0MjA2OTBjNyJ9.EPDiH5wxw1lO7F10qOb6ga9z0l9qapu5mDxBXjk3ESA&download=Item%20System%20Structure.jpg "")







> **如何定義一個新的可拿取物件:**首先為這個item創建好一個script(用膝蓋想都知道這是必要的...)然後使用下圖的方式來註冊(定義)一個新種類的可拿取物件

![](https://tcs.teambition.net/storage/111s5544291626bcec2c5bef1c2f447114de?Signature=eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJBcHBJRCI6IjU5Mzc3MGZmODM5NjMyMDAyZTAzNThmMSIsIl9hcHBJZCI6IjU5Mzc3MGZmODM5NjMyMDAyZTAzNThmMSIsIl9vcmdhbml6YXRpb25JZCI6IiIsImV4cCI6MTU5NTYwNzkxNiwiaWF0IjoxNTk1MDAzMTE2LCJyZXNvdXJjZSI6Ii9zdG9yYWdlLzExMXM1NTQ0MjkxNjI2YmNlYzJjNWJlZjFjMmY0NDcxMTRkZSJ9.F4HrPQBT_y0lkFan7o9Do_DZtNlqdIEQ1wyMD4I_SCQ&download=way%20to%20register%20a%20new%20item.jpg "")

圖中已經加入了三個物件種類, 分別是bit_key, strangeCat和strangeKnowledge



## Item類 (數據結構)

--- Item.cs

本類是用來存處遊戲中物件屬性的數據結構



### 屬性

| 屬性          | 功能        |
| ----------- | --------- |
| string name | 存本item的名字 |
|             |           |



### 構造函數 Constructor

| 函數          | 傳入值               | 功能                              |
| ----------- | ----------------- | ------------------------------- |
| public Item | string name本物件的名字 | 用來初始化這個Item, 存入Item的屬性 (目前只有名字) |



### 函數

| 函數           | 傳入值  | 功能                                                                         |
| ------------ | ---- | -------------------------------------------------------------------------- |
| bool getItem | null | 讓本物件被玩家獲取 --- 本方法應該被normalItem中的getItem方法調用, 請不要調用此函數 除非你不想要在玩家獲得本物件後銷毀本物件 |



## Normal Item 類

--- normalItem.cs

這個類是所有要在遊戲中出現 可供玩家撿起的物品的父類



### 屬性

| 屬性               | 作用                                                    |
| ---------------- | ----------------------------------------------------- |
| Item nItem       | 存這個Item的所有基本屬性                                        |
| string item_name | 這個物件的名字, 預設值"uninitailized item", 請務必在Unity的GUI中修改其名字 |



### 函數

| 函數                    | 傳入值  | 作用                                                                                    |
| --------------------- | ---- | ------------------------------------------------------------------------------------- |
| void Start()          | null | Unity 的 Start函數, 裡面包含了最基本的初始化. 如果要重寫這個函數, 記得要調用父類的Start函數來完成初始化                       |
| void OnTriggerEnter2D | 不可調用 | 碰撞箱被碰撞時的函數 如果不使用碰撞就獲得這一特性，請重寫本函數讓本函數失去功能，或是不要勾帶trigger的碰撞箱 -----本函數會調用this.getItem(); |
| void getItem()        | null | 調用本函數時相當於玩家獲取了本物品 因此將本物品加入物品欄後將本物品銷毀                                                  |





**你需要修改的**

- 把item的名字改了, 記得代碼和外面的框框都要改(其實以外面框框為主...)去把player Control 那邊的 initializeAllItemDictionary





### Case Study: 如何使用Normal Item 系統

- 需求: 定義一顆蘋果(apple) 在場地上, 要能夠被撿起來

![](https://tcs.teambition.net/storage/111sf7ef15894956db6389bce3fa29d077d5?Signature=eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJBcHBJRCI6IjU5Mzc3MGZmODM5NjMyMDAyZTAzNThmMSIsIl9hcHBJZCI6IjU5Mzc3MGZmODM5NjMyMDAyZTAzNThmMSIsIl9vcmdhbml6YXRpb25JZCI6IiIsImV4cCI6MTU5NTYwNzkxNiwiaWF0IjoxNTk1MDAzMTE2LCJyZXNvdXJjZSI6Ii9zdG9yYWdlLzExMXNmN2VmMTU4OTQ5NTZkYjYzODliY2UzZmEyOWQwNzdkNSJ9.swA0QbdCjUAAHM3CMsHpqPsYMEAOjGyVX1VO4XPtJF4&download=apple.png "")





**Step 1:** 把圖片丟到Hierarchy上, 並給她加一個script(這就別讓我教了..)

![](https://tcs.teambition.net/storage/111s09ce5c1fd7a096ef36bee255ceeca209?Signature=eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJBcHBJRCI6IjU5Mzc3MGZmODM5NjMyMDAyZTAzNThmMSIsIl9hcHBJZCI6IjU5Mzc3MGZmODM5NjMyMDAyZTAzNThmMSIsIl9vcmdhbml6YXRpb25JZCI6IiIsImV4cCI6MTU5NTYwNzkxNiwiaWF0IjoxNTk1MDAzMTE2LCJyZXNvdXJjZSI6Ii9zdG9yYWdlLzExMXMwOWNlNWMxZmQ3YTA5NmVmMzZiZWUyNTVjZWVjYTIwOSJ9.-Dd4iByNtpa4jCk8mzMSFr6Dv_WQW1lXTQouGN2oqFQ&download=image-20200407155933448.png "")



**Step2:** 給這個物件加上碰撞箱(collider), 這裡用的是BoxCollider2D, 記得勾上is trigger



![](https://tcs.teambition.net/storage/111seaa4dbd80ee6fcc99b02ffed2adfcd98?Signature=eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJBcHBJRCI6IjU5Mzc3MGZmODM5NjMyMDAyZTAzNThmMSIsIl9hcHBJZCI6IjU5Mzc3MGZmODM5NjMyMDAyZTAzNThmMSIsIl9vcmdhbml6YXRpb25JZCI6IiIsImV4cCI6MTU5NTYwNzkxNiwiaWF0IjoxNTk1MDAzMTE2LCJyZXNvdXJjZSI6Ii9zdG9yYWdlLzExMXNlYWE0ZGJkODBlZTZmY2M5OWIwMmZmZWQyYWRmY2Q5OCJ9._9mMKLDX2SBQWH3O87qEL3IUN19bZ-bp13boZoPln3o&download=image-20200407162415340.png "")





![](https://tcs.teambition.net/storage/111s28c4f4eaa026294d7de2c3ae06266fce?Signature=eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJBcHBJRCI6IjU5Mzc3MGZmODM5NjMyMDAyZTAzNThmMSIsIl9hcHBJZCI6IjU5Mzc3MGZmODM5NjMyMDAyZTAzNThmMSIsIl9vcmdhbml6YXRpb25JZCI6IiIsImV4cCI6MTU5NTYwNzkxNiwiaWF0IjoxNTk1MDAzMTE2LCJyZXNvdXJjZSI6Ii9zdG9yYWdlLzExMXMyOGM0ZjRlYWEwMjYyOTRkN2RlMmMzYWUwNjI2NmZjZSJ9.e7neOMl3wkzPSg6jXwUevrXM-3IjAsHII9TaY6kUjhM&download=image-20200407162507351.png "")



**Step 3:** 讓這個script**繼承自normalItem**

```csp
public class apple : normalItem
{
    ....
}
```

**Step 4:** 在apple的inspector中 我們代碼的component的那個框框下面忽然會多出一個item_name, 在裡面輸入你的item的名字



![](https://tcs.teambition.net/storage/111s32cd9e71624ef75d281a1d3b7398e91b?Signature=eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJBcHBJRCI6IjU5Mzc3MGZmODM5NjMyMDAyZTAzNThmMSIsIl9hcHBJZCI6IjU5Mzc3MGZmODM5NjMyMDAyZTAzNThmMSIsIl9vcmdhbml6YXRpb25JZCI6IiIsImV4cCI6MTU5NTYwNzkxNiwiaWF0IjoxNTk1MDAzMTE2LCJyZXNvdXJjZSI6Ii9zdG9yYWdlLzExMXMzMmNkOWU3MTYyNGVmNzVkMjgxYTFkM2I3Mzk4ZTkxYiJ9.XNudg9m_wATC9y11o73hYQ43rZCyQH0PsL61GFlYiII&download=image-20200407162828703.png "")



**Step 5:** 到玩家控制代碼那邊最下面的function "initializeAllItemDict()" 給你的item註冊, 將你的item註冊到[all item dictionary]裡面去

![](https://tcs.teambition.net/storage/111sfd0cd9497667fa90734a80b899782c83?Signature=eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJBcHBJRCI6IjU5Mzc3MGZmODM5NjMyMDAyZTAzNThmMSIsIl9hcHBJZCI6IjU5Mzc3MGZmODM5NjMyMDAyZTAzNThmMSIsIl9vcmdhbml6YXRpb25JZCI6IiIsImV4cCI6MTU5NTYwNzkxNiwiaWF0IjoxNTk1MDAzMTE2LCJyZXNvdXJjZSI6Ii9zdG9yYWdlLzExMXNmZDBjZDk0OTc2NjdmYTkwNzM0YTgwYjg5OTc4MmM4MyJ9.VAdodDGfDaLvG1H1wjLPNqbYKQjMTp1fEREclEVriTM&download=image-20200407163056976.png "")

**Step 6:** 歡呼吧 你剛剛造出了一個可以被撿起來的item

***









# Charactor Talk System (未完成)

> dialogSystem

onTrigger()

> 如果按e就開始對話, 要在update裡面寫 -- boolstartTalkdisplay(人物名字 + 本事件對應的首個台詞)

Script 格式

> $chapter _1 - n  表示對應chapter **請務必按照順序寫!!! **

> **要從1寫到n (因為程序其實不管你chapter_後面1-n寫得啥2333 那是給你看的)**

> 程序用^&和換行當作分割不同台詞的分割符號 不過盡量用換行分割 不要在句子中使用^&

> ​    ---**chapter**其實更像是一個npc的一套的對話 $choice 3 ^text1 ^ text2 ^ text3



示例範本 (目前已可以正常運作的部分)

```text
$chapter_1
Slime~~~ Slime!!
2
3
4
5
6
7
8
9
10
Slimaaaaaaaaaaaaaaaaaa
$chapter_2
我的名字叫做史萊姆A, 你可以叫我史萊姆A呦!!!
我可以叫你史萊姆B嗎?
什麼? 你說你不是史萊姆? 哈哈! 你這玩笑真的是2333333
你那綠色的頭 一看就知道是史萊姆嘛!!
你說我是怪物? 怎麼可能! 我可是善良的史萊姆呦

```

這個是一個台詞文本的範例











