   M S B A M L   `   `   `  ����>  :Kid, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:KidKid  5   	       Kid.AddCharterWindow   5   	   W SPresentationCore, Version=6.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=6.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   #localclr-namespace:Kid     5   	     � Title$   ��5   	   $	��400��6   $	��500��6    � 
ResizeMode$ NoResize=�6+    � WindowStartupLocation$ CenterScreen=�6A    � WindowStyle$
 None=�6f   .��5	      �  � RowDefinitions 5
   
   �� 5      $��35 �6   �� 5      $	��100 �6   �� 5      �� 5      $��50 �6   .+�5   
   � -   5        $��ToolBar��5      $��3��6   $��0��62   6A   �� 5   
   $&�� Введите название:��6   $��1��6,   $��Center=�69   $
��Left=�6T   $��	10,0,0,50q�6o   �� 5   
   -   5        $��textbox_NameCharter��5      $��1��6-   $��Center=�6:   $
��Left=�6U   $��	10,20,0,0q�6p   $	��300��6�   $��35��6�   $��16(�6�    �� 	MaxLength$ 50��6�   �� 5   
   $��Описание:��6   $��2��6$   $	��Top=�61   $
��Left=�6I   $��	10,0,0,50q�6d   �� 5   
   -   5        $��textbox_Description��5      $��2��6-   $	��Top=�6:   $
��Left=�6R   $��	10,40,0,0q�6m   $	��480��6�   $	��170��6�   $��16(�6�   $
 4000��6�   �� 5   
   -   5        $��Добавить��5      $��3��6$   $	��Top=�61   $��Right=�6I   $��	0,10,10,0q�6e   6x   5      5      