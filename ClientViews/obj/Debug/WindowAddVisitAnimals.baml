   M S B A M L   `   `   `  ����F  BClientViews, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null)clr-namespace:ClientViewsClientViews  5   	   '    !ClientViews.WindowAddVisitAnimals   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   +localclr-namespace:ClientViews     5   	   -   5          � Title$9  3Добавление питомца к визиту��5	   	   $	��450��6-   $	��690��6:   .��5
      � $
��Left=�6   $	��680��6&    � ColumnDefinitions 5   
   �� 5      $
��310* �6   �� 5      $
��321* �6   �� 5      $	��49* �6   .+�5   
   �� -   5         ��Name$ ListBoxSelectedAnimals��5       �� DisplayMemberPath$ Value��62    �� SelectedValuePath$	 Key��6L   $
��Left=�6d   $	��290��6   $��	29,60,0,0q�6�   $	��Top=�6�   $	��250��6�   �� 5   
   -   5        $ ListBoxAvaliableAnimals��5      $
 Name��63   $ Id��6L   $
��Left=�6c   $	��290��6~   $��87.6,60,0,0q�6�   $	��Top=�6�   $	��250��6�   $��1��6�   $��2��6�   �� 5   
   -   5         ��Name$ ButtonAddAnimal��5      ���	#FFFFDCB1$��<-��6_   $
��Left=�6o   $��307,140,0,0q�6�   $	��Top=�6�   $��70��6�   $��20��6�   $��2��6�   �� 5   
   -   5        $ ButtonRemoveAnimal��5      ���	#FFFFDCB1$��->��6e   $
��Left=�6r   $��307,220,0,0q�6�   $	��Top=�6�   $��70��6�   $��20��6�   $��2��6�   �� 5   
   $*��$Выбранные животные:��6   $
��Left=�6.   $��	24,20,0,0q�6I   $	��Top=�6\   $��29��6t   $	��200��6�   �� 5   
   $*��$Доступные животные:��6   $
��Left=�6.   $��87.6,20,0,0q�6I   $	��Top=�6^   $��1��6v   $��29��6�   $	��200��6�   �� 5   
   -   5        $ 
ButtonBond��5      $��Сохранить��6>   ���	#FFFFDCB1$��Center=�6i   $��231,370,314.153,0q�6�   $	��Top=�6�   $��86��6�   $��30��6�   $��2��6�   �� 5   
   -   5        $ ButtonCancel��5      $��Отмена��6B   ���	#FFFFDCB1$��Center=�6j   $��66.6,370,168.153,0q�6�   $	��Top=�6�   $��86��6�   $��30��6�   $��1��6�   5      5      