   M S B A M L   `   `   `  ���� O  KIPS Shipment Tracker, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null;"clr-namespace:IPS_Shipment_TrackerIPS_Shipment_Tracker  %    IPS_Shipment_Tracker.MainWindow   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     4local"clr-namespace:IPS_Shipment_Tracker     -     � Title$/  )Illinois Parcel Service - Tracking System��$	��490��$	��950�� � WindowStyle$
 None=�
���   � � 
ResizeMode$ CanMinimize=� � WindowStartupLocation$ CenterScreen=� � Icon$ 
boxico.ico�� � 	Resources    TextBox.Static.Border �� Color  TextBox.MouseOver.Border  TextBox.Focus.Border  PasswordBoxTemplateCopy �� 
TargetType �� Property	 �� Value-  'System.Windows.Input.KeyboardNavigation
 �� 
TargetType ��Name J� SnapsToDevicePixels ��Name �� Triggers P� Property P� Value �� 
TargetName �� Triggers ]� 
Conditions �� Property �� Value��%�  &	        &	      &	 *     &	 ?     7   7  �� $ 	#FFABAdB3���� $ 	#FF7EB4EA���� $ 	#FF569DE5���� " G�.���  �@G�PasswordChar$		 ●����  � ��#	 � ����  � ��8	   ��  � ��#	 � ����  � ��$	 1q���  �@ TabNavigation$
	 None=���  � ��$
	 Left=���  �@�FocusVisualStyle	 Z� ��  �@J�	AllowDrop	 . ��  �@��PanningMode$	 VerticalFirst=���  �@��IsFlicksEnabled	 .  ��  � ��	 �� "
 G�.R��� $ border��#��z��#��z��#��z�� . ._��� $ PART_ContentHost��|�.  $��Hidden=�$��Hidden=� P�  � {� .  . ��� $ border�� �@J�Opacity$
	 0.56Q�P�  �@J�IsMouseOver . . ��� $ border�� � ��
	 �����P�  �@J�IsKeyboardFocused . . ��� $ border��8	   � �� ]�  �� + �@G�#IsInactiveSelectionHighlightEnabled . ��  �@G�IsSelectionActive .  ./���  �@G�SelectionBrush#	 � /�.��� $
��Left=�$	��465��$��0,25,0,0q�$	��Top=�$	��950�� J� RenderTransformOrigin$ 0.295,0.479&����	#FF49C6FB.+��� -    ��Name$ 
ExitButton��$��X��$
��Left=�$��25��$��922.133,-25,0,0q�$	��Top=�$��17.867�����	#FF49C6FB�� -   $ MinimizeButton��$��_��$
��Left=�$��30��$��895,-30,0,465q�$��Bottom=�$
��23.8�����	#FF49C6FB$��15(�$��Center=�� -    �Name$ 	LogInGrid��$
��Left=�$	��465��$	��Top=�$	��950��$��2��.+��� -    ��Name$ BigLogo��$
��Left=�$	��365��$��	20,40,0,0q�$	��Top=�$	��515��$��BigLogo.PNG���� $
��Left=�$	��115��$��120,255,0,0q�$	��Top=�$	��140��$��Box.png�� J� OpacityMask �	#A5000000�� $
��Left=�$	��115��$��305,255,0,0q�$	��Top=�$	��140��$��Box.png�� �	#A5000000$ 0.5,0.5&�z�V� .~���  �� ScaleY$ 1Q� �� ScaleX$ -1Q���  �� AngleY$ 0Q� �� AngleX$ 0Q���  �� Angle$ 0Q�T� �� $!��*Authorized Personnel Only*��$
��Left=�$��40��$��595,115,0,0q�$	��Top=�$	��300��$��20(�$
��Bold"�$��Segoe UI Black)����	#FF030F4E�� $��Shipping Tracker��$
��Left=�$��60��$��
595,55,0,0q�$	��Top=�$	��300��$��36(�$
��Bold"�
��������� 
���   �$
��Left=�$��5��$��590,110,0,0q����	#FF030F4E$	��Top=�$	��300���� ���	#00000000$
��Left=�$��351.5��$��25,43.5,0,0q�
���   �$	��Top=�$	��505��$��6��G� -     G�Name$  
EmployeeID��$
��Left=�$��40��$��625,240,0,0q�$	��Top=�$	��250�����	#FF49C6FB
���   ����	#FF030F4E$��18(�$��Segoe UI Black)�! G� SelectionBrush
! �   �$��Center=�#���  " G� 	MaxLength$" 10���� $��Employee ID:��$
��Left=�$��40��$��625,195,0,0q�$	��Top=�$	��145��$��20(�$
��Bold"�$��Segoe UI Black)����	#FF030F4E�� $%��Developed by Thomas Owca ©2019��$��Oblique$�$��	ExtraBold"�$��Center=�$��185, 290, 0, 0q�$��10(��� -   # ��Name$# AuthorizeLogIn��$��	Authorize��$
��Left=�$��45��$��625,295,0,0q�$	��Top=�$	��250��$��20(����	#FF030F4E���	#FF030F4E���	#FF49C6FB$
��Bold"��� $��Shipping Tracker��$
��Left=�$��60��$��
594,55,0,0q�$	��Top=�$	��300��$��36(�$
��Bold"�
���   �� -   $��
MainScreen��$
��Left=�$	��450��$��0,5,0,0q�$	��Top=�$	��945��$��2��