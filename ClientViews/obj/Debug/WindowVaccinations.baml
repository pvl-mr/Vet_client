   M S B A M L   `   `   `  ����F  BClientViews, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null)clr-namespace:ClientViewsClientViews  5   	   $    ClientViews.WindowVaccinations   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   +localclr-namespace:ClientViews     5   	   -   5        $	��450��5	   	   $	��900��6     � 
ResizeMode$  NoResize=�6"    � Title$ Прививки��5
      $��Calibri Light)�6   .��5      �  � ColumnDefinitions 5   
   �� 5      $��* �6   �� 5      $	��200 �6   .+�5   
   &   System.Windows.Controls.DataGrid  -   5          Name$ DataGridVaccinations��5      $��0��61      General_datagrid#��[  6A      Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   
Visibility$ Hidden=�6%   1  +System.Windows.Controls.DataGridBoundColumn   Binding 69   ��  �� Path$ ID�6W     5         Header$ Дата��6%   	   Width5  /System.Windows.Controls.DataGridLengthConverter$	 1* 6Q    63   �� $
 Date�6^     5      $' !Название прививки��6%   $	 1* 6^    6@   �� $
 Name�6k     5      $ Описание��6%   $	 1* 6\    67   �� $ Description�6i     5      $ Питомец��6%   $	 1* 6Z    66   �� $ 
AnimalName�6g   5      �� 5   
   $��0��6   $��1��6"   .+�5      �� -   5        
 ��Name$
 	ButtonAdd��5      $&�� Зарегистрировать��6@   $��10 30 10 10q�6[   $��45��6p   ���	#FFFFDCB1  ButtonStyle1#��[ 6�   �� 5      -   5        $
 ButtonUpdate��5      $ ��Редактировать��6F   $��10q�6^   $��45��6j   ���	#FFFFDCB1#��[ 6�   �� 5      -   5        $
 ButtonDelete��5      $��Удалить��6F   $��10q�6X   $��45��6d   ���	#FFFFDCB1#��[ 6�   �� 5      -   5        $
 ButtonRefresh��5      $��Обновить��6H   $��10q�6[   $��45��6g   ���	#FFFFDCB1#��[ 6�   5      � 5   
   $��0��6   $��0��6   .+�5        � ��6   �� *CurrentPage+5!      5"      5#      