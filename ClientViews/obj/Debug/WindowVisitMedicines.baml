   M S B A M L   `   `   `  ����F  BClientViews, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null)clr-namespace:ClientViewsClientViews  5   	   &     ClientViews.WindowVisitMedicines   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   +localclr-namespace:ClientViews     5   	   -   5          � Title$R  LПолучение списка медикаментов по визитам��5	   	   $	��450��6:   $	��450��6G    � 	Resources 5
       �� 
TargetType �� Property �� Value��%�   '��       �� 5   
   " ��6   .�5      ��  � ��$ 16(�6)   �� 5       � ��$ Consolas)�6+   �� 5       � ��$
 Bold"�6+   5      5      .��5      �  � ColumnDefinitions 5   
   �� 5      $
��167* �6   �� 5      $	��54* �6   .+�5   
   �� $$��Выберите визиты:��6   $
��Left=�6+   $��	10,10,0,0q�6F   $	��Top=�6Y   $��33��6q   $	��195��6}   �� 5   
   -   5         ��Name$ ListBoxVisits��5       �� DisplayMemberPath$
 Date��6)    �� SelectionMode$ Multiple=�6B   $
��Left=�6[   $	��315��6v   $��	0,48,-1,0q�6�   $	��Top=�6�   $	��443��6�   $��2��6�   5      �� 5   
   -   5        	 ��Name$	 ButtonExcel��5      $��Excel��6&   $
��Left=�6V   $��
15,380,0,0q�6q   $	��Top=�6�   $	��120��6�   $��30��6�   ���	#FFFFDCB16�   �� 5   
   -   5        $	 
ButtonWord��5      $
��Word��6%   $
��Left=�6S   $��165,380,0,0q�6n   $	��Top=�6�   $	��120��6�   $��30��6�   ���	#FFFFDCB16�   �� 5   
   -   5        $	 ButtonCancel��5      $��Отмена��6'   $��313,380,9,0q�6S   $	��Top=�6h   $	��120��6�   $��30��6�   $��2��6�   ���	#FFFFDCB16�   5      5      