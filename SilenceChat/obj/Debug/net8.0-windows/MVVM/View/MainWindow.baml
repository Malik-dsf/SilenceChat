   M S B A M L   `   `   `  ����L  HSilenceChatClient, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null)clr-namespace:SilenceChatSilenceChat  5   	   S.clr-namespace:SilenceChatClient.MVVM.ViewModel SilenceChatClient.MVVM.ViewModel  61       SilenceChat.MainWindow   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   +localclr-namespace:SilenceChat     5   	   D	ViewModel.clr-namespace:SilenceChatClient.MVVM.ViewModel     61     � 
ResizeMode$  CanMinimize=�5   	   
������  � Title$ 
SilentChat��5
   	   $	��520��5   	   $	��920��5   	    � DataContext 5      4  .SilenceChatClient.MVVM.ViewModel.MainViewModel  5   
   .��5      �� ���#272537$��5q�6"   ._�5   
   � .+�5      �  � ColumnDefinitions 5      �� 5      $	��200 �6'   �� 5      .+�5      ]� .+�5      �� $��25��6   $	��Top=�6+   $��Center=�6@   ���#e6e6e6$��5q�6p   ���#7575a3��6�   �� *
Username+ �� UpdateSourceTrigger$ PropertyChanged=��� 5      $��25��6   $	��Top=�6)   $��	Connexion��6>   ��6R   �� *ConnectToServeurCommand+�� 5       
������ ��6   �� *Users+��5!      �� 5"      .R�5#   "   �� ���#290066��6A   �� *
Username+5$      5'      5(      �� 5*      $��1��6   .+�5+      �� -   5        $	��380��5+      ���#8585ad$��8q�6n   ��6y   �� *
Messages+�� 5-       �� Orientation$ 
Horizontal=�6!   .+�5.      �� $��55��6"   $	��545��6.   $��Center=�6:   ���#7575a3$
��Left=�6q   $��5q�6�   ���#e6e6e6��6�   �� *	Message+$ PropertyChanged=��� 50      $��55��6!   $
��Send��6,   ��6;   �� *SendMessageCommand+51      52      55      56      58      5:      