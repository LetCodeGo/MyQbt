# 主要功能

在执行离线功能时请先备份文件夹，qBittorrent的在AppData\Local\qBittorrent\BT_backup，µTorrent的为resume.dat  
1、添加种子时，自动在保存路径上加上中文名，在qBittorrent上也添加中文名（中文名为添加的种子文件名，可同时添加多个）  
2、qBittorrent的Tracker替换  
3、如果种子所对应的实际文件磁盘名改变了，可以修改保存的种子信息，重新对应上，不需重新校验  
4、辅种功能（勾选跳过hash检测时，检测文件名及大小是否相同，两项都一致可认为是相同文件）  
5、移除实际文件已不存在的种子  

## qBittorrent在线功能（需qBittorrent开启Web用户界面，qBittorrent v4.1+以上版本）

![image](https://github.com/LetCodeGo/MyQbt/blob/master/Images/qBittorrent_online_main.png)

## qBittorrent离线功能（需关闭qBittorrent）

![image](https://github.com/LetCodeGo/MyQbt/blob/master/Images/qBittorrent_offline_main.png)

## µTorrent离线功能（需关闭µTorrent）

![image](https://github.com/LetCodeGo/MyQbt/blob/master/Images/utorrent_offline_main.png)

# 感谢

感谢以下的项目

* [BencodeNET](https://github.com/Krusen/BencodeNET)
* [Newtonsoft.Json](https://github.com/JamesNK/Newtonsoft.Json)
* [qBittorrentSharp](https://github.com/teug91/qBittorrentSharp)
* [qBittorrent Web API Documentation](https://github.com/qbittorrent/qBittorrent/wiki/Web-API-Documentation)
