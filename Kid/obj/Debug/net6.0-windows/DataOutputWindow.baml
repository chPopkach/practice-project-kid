   M S B A M L   `   `   `  ����>  :Kid, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:KidKid  5   	       Kid.DataOutputWindow   5   	   W SPresentationCore, Version=6.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=6.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   #localclr-namespace:Kid     5   	     � Title$   ��5   	   $	��485��6   $
��1000��6    � 
ResizeMode$ NoResize=�6,    � WindowStartupLocation$ CenterScreen=�6B    � WindowStyle$
 None=�6g   .��5	      �  � ColumnDefinitions 5
   
   �� 5      $	��850 �6   �� 5      $	��150 �6    � RowDefinitions 5   
   �� 5      $��35 �6   �� 5      $	��100 �6   �� 5      $	��350 �6   .+�5   
   � -   5        $��ToolBar��5      $��3��6   $��0��62   6A   �� 5   
   $"��Данные таблицы:��6   $��0��6*   $��1��6:   $
��Left=�6G   $��Center=�6b   $��	10,0,0,20q�6}   �� 5   
   -   5        $��comboBox_changeDataGrid��5      $��0��62   $��1��6B   $
��Left=�6O   $��Center=�6j   $��	10,50,0,0q�6�   $	��150��6�   6�   �� 5   
   -   5        $��
button_Add��5      $��Добавить��6#   $��0��66   $��1��6F   $
��Left=�6S   $��Center=�6n   $��
170,50,0,0q�6�   6�   �� 5   
   -   5        $��button_IsCompleted��5      $��Проведено��6+   $��0��6?   $��1��6O   $
��Left=�6\   $��Center=�6w   $��
500,50,0,0q�6�   6�   �� 5   
   -   5        $��button_ReportGeneration��5      $)��#Сформировать отчет��60   $	��200��6M   $��0��6Y   $��1��6i   $��Right=�6v   $��Center=�6�   $��	0,50,10,0q�6�   6�   �� 5   
   $��Поиск:��6   $��0��6!   $��1��61   $��Center=�6>   $��Center=�6[   $��10,0,280,20q�6v   �� 5   
   -   5        $��textbox_Search��5      $��0��6(   $��1��68   $��Center=�6E   $��Center=�6b   $��	10,0,0,20q�6}   $	��200��6�   $��30��6�   $��16(�6�   6�   &   System.Windows.Controls.DataGrid  5   
   -   5        $��datagrid��5         AutoGenerateColumns$ False��6#      
IsReadOnly$
 True��6?   $��0��6Q   $��2��6a   $��16(�6n   $
��True��6|   6�   5      5       