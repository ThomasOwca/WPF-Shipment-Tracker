   M S B A M L   `   `   `  ����O  KIPS Shipment Tracker, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null;"clr-namespace:IPS_Shipment_TrackerIPS_Shipment_Tracker  5   	   %    IPS_Shipment_Tracker.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   4local"clr-namespace:IPS_Shipment_Tracker     5   	   -   5          � Title$/  )Illinois Parcel Service - Tracking System��5   	   $	��490��6;   $	��950��6H    � WindowStyle$
 None=�6T   
���   � � 
ResizeMode$ CanMinimize=�6z    � WindowStartupLocation$ CenterScreen=�6�    � Icon$ Box.png��6�    � 	Resources 5	         TextBox.Static.Border �� Color  TextBox.MouseOver.Border  TextBox.Focus.Border  PasswordBoxTemplateCopy �� 
TargetType �� Property	 �� Value-  'System.Windows.Input.KeyboardNavigation
 �� 
TargetType ��Name J� SnapsToDevicePixels ��Name �� Triggers P� Property P� Value �� 
TargetName �� Triggers ]� 
Conditions �� Property �� Value��%�  &	        &	 #     &	 F     &	 i     7   7  �� 5
   
   $ 	#FFABAdB3��68   �� 5   
   $ 	#FF7EB4EA��6;   �� 5   
   $ 	#FF569DE5��67   �� 5   
   " G�60   .�5      ��  �@G�PasswordChar$		 ●��6-   �� 5       � ��#	 � ��6+   �� 5       � ��8	   6,   �� 5       � ��#	 � ��6+   �� 5       � ��$	 1q�60   �� 5       �@ TabNavigation$
	 None=�6A   �� 5       � ��$
	 Left=�6;   �� 5       �@�FocusVisualStyle	 61   Z� �� 5       �@J�	AllowDrop	 . 6*   �� 5       �@��PanningMode$	 VerticalFirst=�69   �� 5       �@��IsFlicksEnabled	 .  67   �� 5       � ��	 5      �� 5      "
 G�6&   .R�5      �� $ border��6!   #��z��61   #��z��6]   #��z��6�    . ._�5      �� $ PART_ContentHost��6+   |�.  $��Hidden=�6W   $��Hidden=�6~   5       5      P� 5        � {� .  . �5!   "   �� $ border��6<    �@J�Opacity$
	 0.56Q�6P   5"      P� 5#       �@J�IsMouseOver . . �5$   "   �� $ border��6@    � ��
	 �����6T   5%      P� 5&       �@J�IsKeyboardFocused . . �5'   "   �� $ border��6@   8	   � ��6T   5(      5*      5,       5-      ]� 5.       5/      �� 50      + �@G�#IsInactiveSelectionHighlightEnabled . 6S   �� 51       �@G�IsSelectionActive .  6A   ./�53      ��  �@G�SelectionBrush#	 � /�67   54      56      57      .��58      � $
��Left=�6   $	��465��6&   $��0,25,0,0q�63   $	��Top=�6E   $	��950��6]    J� RenderTransformOrigin$ 0.295,0.479&�6i   ���	#FF49C6FB.+�59   
   �� -   5         ��Name$ 
ExitButton��59      $��X��6$   $
��Left=�60   $��25��6K   $��922.133,-25,0,0q�6W   $	��Top=�6p   $��17.867��6�   ���	#FF49C6FB6�   �� 5:   
   -   5        $ MinimizeButton��5:      $��_��6(   $
��Left=�64   $��30��6O   $��895,-30,0,465q�6[   $��Bottom=�6r   $
��23.8��6�   ���	#FF49C6FB$��15(�6�   $��Center=�6�   6=  � 5;   
   -   5         �Name$ 	LogInGrid��5;      $
��Left=�6"   $	��465��6=   $	��Top=�6J   $	��950��6b   $��2��6n   .+�5<      �� -   5         ��Name$ BigLogo��5<      $
��Left=�6%   $	��365��6@   $��	20,40,0,0q�6M   $	��Top=�6`   $	��515��6x   $��BigLogo.PNG��6�   �� 5=      $
��Left=�6   $	��115��6/   $��120,255,0,0q�6<   $	��Top=�6Q   $	��140��6i   $��Box.png��6u    J� OpacityMask �	#A50000006�   �� 5>      $
��Left=�6   $	��115��6/   $��305,255,0,0q�6<   $	��Top=�6Q   $	��140��6i   $��Box.png��6u    �	#A5000000$ 0.5,0.5&�6�   z�5?      V� 5@      .~�5A      ��  �� ScaleY$ 1Q�6)    �� ScaleX$ -1Q�64   �� 5B       �� AngleY$ 0Q�6(    �� AngleX$ 0Q�63   �� 5C       �� Angle$ 0Q�6*   T� 5D      5E      5G      �� 5H      $!��*Authorized Personnel Only*��6   $
��Left=�6:   $��40��6U   $��595,115,0,0q�6a   $	��Top=�6v   $	��300��6�   $��20(�6�   $
��Bold"�6�   $��Segoe UI Black)�6�   ���	#FF030F4E6�   �� 5I      $��Shipping Tracker��6   $
��Left=�6/   $��60��6J   $��
595,55,0,0q�6V   $	��Top=�6j   $	��300��6�   $��36(�6�   $
��Bold"�6�   
�������6�   �� 5J      
���   �$
��Left=�6%   $��5��6@   $��590,110,0,0q�6K   ���	#FF030F4E$	��Top=�6s   $	��300��6�   �� 5K      ���	#00000000$
��Left=�6)   $��351.5��6D   $��25,43.5,0,0q�6S   
���   �$	��Top=�6w   $	��505��6�   $��6��6�   G� 5L      -   5          G�Name$  
EmployeeID��5L      $
��Left=�6.   $��40��6I   $��625,240,0,0q�6U   $	��Top=�6j   $	��250��6�   ���	#FF49C6FB
���   ����	#FF030F4E$��18(�6�   $��Segoe UI Black)�6�   ! G� SelectionBrush
! �   �$��Center=�6  #���  63  " G� 	MaxLength$" 10��6e  �� 5M      $��Employee ID:��6   $
��Left=�6+   $��40��6F   $��625,195,0,0q�6R   $	��Top=�6g   $	��145��6   $��20(�6�   $
��Bold"�6�   $��Segoe UI Black)�6�   ���	#FF030F4E6�   �� 5N      $%��Developed by Thomas Owca ©2019��6   $��Oblique$�6=   $��	ExtraBold"�6Q   $��Center=�6h   $��185, 290, 0, 0q�6�   $��10(�6�   �� 5O      -   5        # ��Name$# AuthorizeLogIn��5O      $��	Authorize��6-   $
��Left=�6A   $��45��6\   $��625,295,0,0q�6h   $	��Top=�6}   $	��250��6�   $��20(�6�   ���	#FF030F4E���	#FF030F4E���	#FF49C6FB$
��Bold"�6�   6  �� 5P      $��Shipping Tracker��6   $
��Left=�6/   $��60��6J   $��
594,55,0,0q�6V   $	��Top=�6j   $	��300��6�   $��36(�6�   $
��Bold"�6�   
���   �6�   5Q      � 5R   
   -   5        $��
MainScreen��5R      $
��Left=�6!   $	��450��6<   $��0,5,0,0q�6I   $	��Top=�6Z   $	��945��6r   $��2��6~   5S      5T      