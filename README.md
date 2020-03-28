# 主要功能

在线添加种子，qBittorrent v4.1+ 或 Transmission v2.8+  
在执行离线功能时，请先备份文件夹或文件，qBittorrent的为%localappdata%\qBittorrent\BT_backup文件夹，µTorrent的为resume.dat文件  
1、qBittorrent、Transmission在线添加种子，自动在保存文件夹头添加中文（中文名为添加的种子文件名，可同时添加多个）或手动设置  
2、qBittorrent离线操作fastresume文件，对Tracker、保存路径进行字符串替换  
3、辅种功能，只需要使实际文件保存在相同路径，即可辅种（勾选跳过hash检测时，检测文件名及大小是否相同，两项都一致可认为是相同文件）  
4、qBittorrent离线操作fastresume文件，µTorrent离线操作resume.dat文件，移除实际文件已不存在的种子  

# 主界面

![image](https://github.com/LetCodeGo/MyQbt/blob/master/Images/main.png)

# 感谢以下项目

* [BencodeNET](https://github.com/Krusen/BencodeNET)
* [Newtonsoft.Json](https://github.com/JamesNK/Newtonsoft.Json)
* [qBittorrentSharp](https://github.com/teug91/qBittorrentSharp)
* [qBittorrent Web API Documentation](https://github.com/qbittorrent/qBittorrent/wiki/Web-API-Documentation)
* [Transmission.API.RPC](https://github.com/Beatlegger/Transmission.API.RPC)
