# <center>TablePet</center>

### LOG
---
##### 功能：

- [x] 透明窗口
- [x] 鼠标任意拖拽：拖拽时显示sitl，松开鼠标播放一遍start，后默认回到relax
- [x] 自动切换动画：10种随机类型，1s时钟触发，使用自适应阈值调节切换频率
- [x] 窗口移动：动画为movel和mover时，1ms时钟改变窗口x坐标，到达左/右屏幕边缘时停止
- [x] 固定对白：单击时发送系统通知，内容为6种对白随机，通知用NuGget的包实现
- [x] 改进大小：适配不同屏幕尺寸
- [x] 右键菜单：
    - 置于顶层 (默认选中)
    - 调整大小 (小/中/大)
    - 禁止走动
    - 坐下 & 睡觉 (固定动作) 睡觉时无法坐下
    - 退出
- [x] 读取系统异常信息 (内存占用、CPU) 并提示 （为方便展示效果改成定时通报）
- [x] 改进拖拽：左右方向不同
- [x] 系统托盘图标 完成图标，后续考虑是否加入右键菜单
- [x] 改进固定对白：人物头上气泡
---

##### 计划：

- [ ] 右键菜单：
    - [ ] 双屏的适配
    - [ ] 语音与动作or固定对白对应，或AI语音
- [ ] 扩展功能：
    - [ ] <font color=red>便签/备忘录</font>
        - [x] 单个新建(便签外观)
        - [x] Listbox绑定数据
        - [x] ObservableCollection<\T>实现实时刷新
        - [ ] 设置选项：提供几个背景颜色方案，字体和字号，透明度
        - [ ] 文件夹
        - [x] Icon按钮
        - [ ] 连接数据库
    - [ ] 闹钟/计时器/日历
    - [ ] <font color=red>GPT对话</font>
        - [x] 输入输出框
        - [x] 上下文连续
        - [x] 角色扮演
        - [x] 使用pythonnet连接Python和.NET, 用Python实现OpenAI API的调用
        - [x] 改进外观，和气泡结合
        - [x] 像Siri一样, 通过意图提取，用对话调用功能
        - [ ] 设计并利用实体识别
    - [ ] 交互培养、心情值、投喂互动 (需要更多动画)
        - [x] 心情条
    - [ ] 置顶的图片查看器
    - [ ] 快捷启动
    - [ ] <font color=red>rss订阅 & 推送</font>
        - [x] 用包获取Feed & 读取Feed & 解析Feed
        - [x] Listbox遍历显示Feed中的每一个Entry。设计美观的模版, 包含标题(链接到原网页), <font color=red>Feed的名称和作者</font>, 最后更新时间, 内容, <font color=red>序号, 以及功能Icon按钮。</font> (红字还没实现)
        - [x] Listbox放于ScrollViewer内, 并重写滚动处理方法, bubble到外层, 避免被Listbox截断。效果是可以随意滚动, 而不是只能滚动到下一个Item在最顶端的显示。
        - [ ] 所有Feed源的列表和联动
        - [ ] 解析xml文件
        - [ ] 文件夹
        - [ ] 收藏
        - [ ] 已读未读
        - [ ] 转发
        - [ ] Tag
        - [ ] Feed的Properties：界面已搭建完毕
    - [ ] 和桌面图标互动
- [ ] 数据模型和数据库
- [ ] 改进透明窗口：提升显存效率
- [ ] 改进行走：上下 & 斜方向 (需要更多动画)
- [ ] 改进动画切换：不是随机，而是有一定逻辑顺序的，或者更好的概率分布
- [ ] 使用爬虫，推送微博热搜，随机推荐电影或音乐
