   M S B A M L   `   `   `  ����F  BClientViews, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null)clr-namespace:ClientViewsClientViews  5          ClientViews.App   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      +localclr-namespace:ClientViews     5        �� 	Resources  5         TextBox.Static.Border �� Color  TextBox.MouseOver.Border  TextBox.Focus.Border  FocusVisual �� Property �� Value �� StrokeDashArray J� SnapsToDevicePixels  Button.Static.Background  Button.Static.Border  Button.MouseOver.Background  Button.MouseOver.Border  Button.Pressed.Background 	 Button.Pressed.Border 
 Button.Disabled.Background  Button.Disabled.Border  Button.Disabled.Foreground  ButtonStyle1 �� 
TargetType �� 
TargetType ��Name	 �� CornerRadius
 ��Name �� Triggers P� Property P� Value �� 
TargetName  TextBoxStyle1-  'System.Windows.Input.KeyboardNavigation ��Name �� Triggers ]� 
Conditions �� Property �� Value  ButtonStyle2  General_datagrid&   System.Windows.Controls.DataGrid��%�  &	        &	 #     &	 D     &	 e     &	     &	 2    &	 U    &	 x    &	 �    &		 �    &	
 �    &	     &	 '    &	 J    7  7  7  7  7 	 7 
 7  7  &	 P    7  7  &	 �    &	 �    �� 5   
   $ 	#FFABAdB3��68   �� 5	   
   $ #FFE4B5��6;   �� 5
   
   $ #FFE4B5��67   �� 5   
   .�5      ��  � �� 5      �� 5      .R�5      �� $��2q�6$   $	 1 2R�6/    . $��1��6`   #��� ��6t   5      5      5      �� 5   
   $ 	#FFDDDDDD��6;   �� 5   
   $ 	#FF707070��67   �� 5   
   $ 	#FFBEE6FD��6>   �� 5   
   $ 	#FF3C7FB1��6:   �� 5   
   $ 	#FFC4E5F6��6<   �� 5   
   $ 	#FF2C628B��68   �� 5   
   $ 	#FFF4F4F4��6=   �� 5   
   $ 	#FFADB2B5��69   �� 5   
   $ 	#FF838383��6=   �� 5   
   " ��6%   .�5      ��  �@�FocusVisualStyle8   61   �� 5       � �� �#Fafafa6+   �� 5        � �� �#aaaaaa6,   �� 5!       � ��# � ��6+   �� 5"       � ��$ 0q�60   �� 5#       � ��$ Center=�6;   �� 5$       � ��$ Center=�69   �� 5%       � ��$ 1q�6(   �� 5&       � ��$ 20(�6)   �� 5'       � �� 5(      �� 5)      " ��6&   .R�5*      �� $ border��6!   $	 7��61   #��z��6B   #��z��6l   #��z��6�    . ._�5+      �� $
 contentPresenter��6/   |�.  #��z��6[   #��z��6�   ��. # z 6�   #��z��6  5,       5-      P� 5.       �@��IsDefaulted . . �5/   "   �� $ border��6@   # � ��6T    � ��50      P� 51       �@J�IsMouseOver . . �52   "   �� $ border��6?   8   � ��6S   �� 53   "   $ border��6@   8   � ��6T   54      P� 55       � �� . . �56   "   �� $ border��6?   8   � ��6S   �� 57   "   $ border��6@   8   � ��6T   58      P� 59       � {� .  . �5:   "   �� $ border��6?   8   � ��6S   �� 5;   "   $ border��6@   8   � ��6T   �� 5<   "   $ contentPresenter��6K   8   � ��6i   5=      5?      5A      5B      �� 5D   
   " ��6&   .�5E      ��  � �� �#d0d0d06,   �� 5F       � ��# � ��6+   �� 5G       � ��$ 0 0 0 2q�60   �� 5H       �@ TabNavigation$
 None=�6A   �� 5I       � ��$
 Left=�6;   �� 5J       � ��$ Bottom=�69   �� 5K       �@�FocusVisualStyle 61   Z� �� 5L       �@J�	AllowDrop . 6*   �� 5M       �@��PanningMode$ VerticalFirst=�69   �� 5N       �@��IsFlicksEnabled .  67   �� 5O       � ��$ 16(�6)   �� 5P       � ��$
 10 6q�6'   �� 5Q       � ��$ 32��6'   �� 5R       � �� 5S      �� 5T      " ��6&   .R�5U      �� $ border��6!   $	 1��61   ���#ffffff#��z��5V   !   #��z��5W   !    . ._�5X      �� $ PART_ContentHost��6+   |�.  $��Hidden=�6W   $��Hidden=�6~   5Y       5Z      P� 5[       � {� .  . �5\   "   �� $ border��6<    �@J�Opacity$
 0.56Q�6P   5]      P� 5^       �@J�IsMouseOver . . �5_   "   �� $ border��6@   8    � ��6T   5`      P� 5a       �@J�IsKeyboardFocused . . �5b   "   �� $ border��6@   8   � ��6T   5c      5e      5g       5h      ]� 5i       5j      �� 5k      + �@��#IsInactiveSelectionHighlightEnabled . 6S   �� 5l       �@��IsSelectionActive .  6A   ./�5n      ��  �@��SelectionBrush# � /�67   5o      5q      �� 5s   
   " ��6%   .�5t      ��  � �� �#Fafafa6+   �� 5u       � �� �#aaaaaa6,   �� 5v       � ��$ 1q�60   �� 5w       � ��$ Center=�6;   �� 5x       � ��$ Center=�69   �� 5y       � ��$ 18(�6)   5z      �� 5{      "  6*   .�5|      ��  �@ AutoGenerateColumns .  64   �� 5}       �@ CanUserAddRows .  6/   �� 5~       �@ CanUserResizeRows .  62   �� 5       �@ CanUserReorderColumns .  66   �� 5�       �@ CanUserSortColumns .  63   �� 5�       �@ CanUserDeleteRows .  62   �� 5�       � ��$( " {StaticResource Label_fontFamily})�6+   �� 5�       � ��$ 14(�6)   �� 5�       �@ SelectionMode$ Single=�6.   5�      5�      5�      