   M S B A M L   `   `   `  ����>  :Kid, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:KidKid  5   	       Kid.AddEventWindow   5   	   W SPresentationCore, Version=6.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=6.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   #localclr-namespace:Kid     5   	     � Title$   ��5   	   $	��600��6   $	��800��6    � 
ResizeMode$ NoResize=�6+    � WindowStartupLocation$ CenterScreen=�6A    � WindowStyle$
 None=�6f   .��5	      �  � ColumnDefinitions 5
   
    � RowDefinitions 5   
   �� 5      $��35 �6   �� 5      $	��100 �6   �� 5      �� 5      .+�5   
   � -   5        $��ToolBar��5      $��3��6   $��0��62   6A   �� 5   
   $ ��Наименование: ��6   $��1��6)   $��Center=�66   $
��Left=�6Q   $��	10,0,0,35q�6l   �� 5   
   -   5        $��textbox_Name��5      $��1��6&   $��Center=�63   $
��Left=�6N   $��	10,35,0,0q�6i   $��35��6|   $	��200��6�   $��16(�6�    �� 	MaxLength$	 100��6�   �� 5   
   $��
Дата: ��6   $��1��6!   $��Center=�6.   $��Center=�6I   $��10,0,135,35q�6f   �� 5   
   -   5        $��textbox_Date��5      $��1��6&   $��Center=�63   $��Center=�6N   $��	10,35,0,0q�6k   $��35��6~   $	��200��6�   $��16(�6�   $ 10��6�   �� 5   
   $"��Ответственный: ��6   $��1��6*   $��Center=�67   $��Right=�6R   $��
10,0,65,35q�6n   �� 5   
   -   5        $��combobox_Employees��5      $��1��6-   $��Center=�6:   $��Right=�6U   $��	0,35,10,0q�6q   $��35��6�   $	��200��6�   $��16(�6�   �� 5   
   $��Описание: ��6   $��2��6%   $	��Top=�62   $
��Left=�6J   $��
10,10,0,35q�6e   �� 5   
   -   5        $��textbox_Description��5      $��2��6-   $��2��6:   $��Center=�6K   $��Center=�6f   $	��780��6�   $	��330��6�   $��0,0,0,30q�6�   $��16(�6�   $
 4000��6�   �� 5   
   -   5        $��Добавить��5      $��3��6$   $��Bottom=�61   $��	0,0,10,10q�6L   $��Right=�6_   6{   5!      5"      