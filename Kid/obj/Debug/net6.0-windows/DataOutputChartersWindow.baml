   M S B A M L   `   `   `  ����>  :Kid, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:KidKid  5   	   "    Kid.DataOutputChartersWindow   5   	   W SPresentationCore, Version=6.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=6.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   #localclr-namespace:Kid     5   	     � Title$   ��5   	   $	��385��6   $	��400��6    � 
ResizeMode$ NoResize=�6+    � WindowStartupLocation$ CenterScreen=�6A    � WindowStyle$
 None=�6f   .��5	      �  � ColumnDefinitions 5
   
    � RowDefinitions 5   
   �� 5      $��35 �6   �� 5      $��50 �6   �� 5      $��50 �6   �� 5      .+�5   
   � -   5        $��ToolBar��5      $��3��6   $��0��62   6A   �� 5   
   -   5        $+��%Добавить сотруднику��5      $��1��6/   $
��Left=�6<   $��10,0,0,0q�6W   $	��200��6}   �� 5   
   -   5        $!��Добавить новую��5      $��2��6*   $
��Left=�67   $��10,0,0,0q�6R   $	��200��6p   �� 5   
   -   5        $��combobox_Charters��5      $��1��6,   $��Right=�69   $��30��6U   $	��175��6a   $��0,0,10,0q�6m   �� 5   
   -   5        $��textblock_Count��5      $��2��6+   $��Right=�68   $��Center=�6T   $��0,0,10,0q�6o   $��50��6�   $��30��6�   &   System.Windows.Controls.DataGrid  5   
   -   5        $��datagrid��5         AutoGenerateColumns$ False��6#      
IsReadOnly$
 True��6?   $��0��6Q   $��3��6a   $��16(�6n   $
��True��6|      RowDetailsTemplate 5      �� 5      .R�5       �� $��16(�6>   $��Center=�6L   $	��380��6g   $
��Wrap=�6s   ��6    �� *DescriptionC+6s   5!      5#      5%      5&      