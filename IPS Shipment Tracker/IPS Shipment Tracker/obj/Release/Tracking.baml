   M S B A M L   `   `   `  ���� O  KIPS Shipment Tracker, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null;"clr-namespace:IPS_Shipment_TrackerIPS_Shipment_Tracker  #    IPS_Shipment_Tracker.Tracking   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     4local"clr-namespace:IPS_Shipment_Tracker     -     �Name$  TrackingWindow�� � Title$/ )Illinois Parcel Service - Tracking System��$	��570��$
��1100�� � WindowState$ Normal=� � WindowStyle$ SingleBorderWindow=����	#FF49C6FB � Icon$ 
boxico.ico�� � WindowStartupLocation$ CenterScreen=� � 	Resources ��%    .��� -    �Name$ displayAllGrid��.+�� -   $ displayShipmentsGrid�� � ColumnDefinitions �� $��* ��� $��* ��� $��* ��� $��* �	 � RowDefinitions	 �� $��55 ��� $
��143* ��� $
��327* �.+��� -   $��ButtonShipments��$��0��$��0��$��	Shipments��$��Center=�$��Center=�
���   �
�������$��18(�
���   �$��0,0,1,1q��� -   $��ButtonFindShipment��$��1��$��0��$��Find Shipment��$��Center=�$��Center=�
���   �
�������$��18(�$��0,0,1,1q�
���   ��� -   $��ButtonFindCustomers��$��2��$��0��$��Find Customer��$��Center=�$��Center=�
���   �
�������$��18(�$��0,0,1,1q�
���   ��� -   $��
ButtonExit��$��3��$��0��$
��Exit��$��Center=�$��Center=�
���   �
�������$��18(�$��0,0,0,1q�
���   �&   System.Windows.Controls.DataGrid  -   $��AllShipments��$��0��$��3��$��1��$��2��$
��22.5q�
   RowStyle
 ��  �� 
TargetType)  #System.Windows.Controls.DataGridRow"   �� Triggers ��  �� Binding �� *Status+ �� Value 	Delivered.a���  �� Property � �� �� Value
 �2�2���  �� *Status+ Label Printed.a���  � ��
 �  ����  �� *Status+ 
In-Transit.a���  � �� �	#FFF4A933��  �� *Status+ Out For Delivery.a���  � �� �	#FF00FF68��  �� *Status+ On Way To Carrier.a���  � ��
 � ���   ColumnHeaderStyle �� =  7System.Windows.Controls.Primitives.DataGridColumnHeader"  .���  � ��
 �   ���  � ��
 �������  � ��$	 130����  � ��$ 3q� P�  P� Property �@J�IsMouseOver P� Value . . ���  � ��
 �������  � ��
 �   � J� Effect 3  -System.Windows.Media.Effects.DropShadowEffect     Color$ Black��   ShadowDepth$ 8Q�   RenderingBias$ Performance=��� -	    ��Name$ DisplayStackPanel��$��3��$��1��$��2��$��20q� � DataContext �� *SelectedItem+ �� ElementName$ AllShipments��.+��� -
    ��Name$ refreshButton��$��Refresh Data��
���  ��
�������$��Center=�$��Medium"��� $��Tracking #:��$��18(�$
��Bold"��� -    ��Name$ trackingTextBox��$��35��$��Center=�$��Center=�
���   �
�������$��16(�|�. 
���   �   styleTextBox#��[  ���� *[Tracking #]+ �� Mode$ OneWay=��� $��Last Updated Date:��$��18(�$
��Bold"��� -   $ lastUpdatedTextBox��$��35��$��Center=�$��Center=�
���   �
�������
���   �$��16(� �� 
IsReadOnly . |�.  #��[  ���� *[Date Updated]+$ OneWay=��� $��Shipped Date:��$��18(�$
��Bold"��� -   $ shippedDateTextBox��$��35��$��Center=�$��Center=�
���   �
�������
���   �$��16(� . |�.  #��[  ���� *[Date Initiated]+$ OneWay=��� $��Estimated Delivery:��$��18(�$
��Bold"��� -   $ estimatedDeliveryTextBox��$��35��$��Center=�$��Center=�
���   �
�������
���   �$��16(� . |�.  #��[  ���� *[Date Updated]+$ OneWay=��� $��Status:��$��18(�$
��Bold"��� -   $ packageStatusTextBox��$��35��$��Center=�$��Center=�$��18(�$
��Bold"� . |�.  ���� *Status+$ OneWay=�.������ " �� ��  �� *Status+ 	Delivered.a���  � ��
 �2�2���  �� *Status+ Label Printed.a���  � ��
 �  ����  �� *Status+ 
In-Transit.a���  � �� �	#FFF4A933��  �� *Status+ Out For Delivery.a���  � �� �	#FF00FF68��  �� *Status+ On Way To Carrier.a���  � ��
 � �����  �� *SelectedItem+	 False.a���  � ��
 �   �.���� $��SmallLogo.PNG��$��48��� -   $ findTrackingNumberGrid�� �� $��* ��� $��* ��� $��* ��� $��50 �	 �� $��55 ��� $	��100 ��� $��* ��� $	��100 �.+��� -    ��Name$ searchByComboBox��$��40��$��1��$��30.467,25,29.533,25q�$��16(�$��Center=�$��Center=�  �� SelectedIndex$  0��.@��� $��Search by Tracking Number���� $��Search by Order ID���� -   $ 
enterLabel��$��Enter Tracking Number: ��$��1��$��1��$��15q�$��Center=�$��26(�$
��Bold"�$��Center=��� -   $ enterTextBox��$��1��$��2��$��2��$��20q�$��40��! �� 	MaxLength$! 16��$��Center=�$��18(�$��8,0,0,0q��� -   $ searchPackageLabel��$��2��$��1��$��Search��$��304.267,30,3.6,30q�
���   �
����� �$��Center=�$��Center=�$��2���� -   " ��Name$" backgroundRectangle��
�������$��2��$��2��$��0��$��2��$��10,10,10,35.4q�# �� RadiusX$# 12��$ �� RadiusY$$ 12��$��8���� -   $ lblTrackingNumber��$��2��$��Tracking Number: ��$��20, 20, 0 ,0q�$��15(�$
��Bold"��� -   $ 	lblStatus��$��Status: ��$��2��$��20, 50, 0 ,0q�$��15(�$
��Bold"��� -   $ lblDepartHub��$��Departure Hub: ��$��2��$��20, 80, 0 ,0q�$��15(�$
��Bold"��� -   $ lblDestinationHub��$��Destination Hub: ��$��2��$��20, 110, 0 ,0q�$��15(�$
��Bold"��� -   $ lblCustomerID��$��Customer ID: ��$��2��$��20, 140, 0 ,0q�$��15(�$
��Bold"��� -   $ lblShipDate��$��Date Shipped: ��$��2��$��20, 170, 0 ,0q�$��15(�$
��Bold"��� -   $ lblLastUpdated��$��Last Updated: ��$��2��$��20, 200, 0 ,0q�$��15(�$
��Bold"��� -   $ lblDeliveredDate��$��Date Delivered: ��$��2��$��20, 230, 0 ,0q�$��15(�$
��Bold"��� $��Box.png��$��2��$��2��$��
20,45,10,0q�$	��300���� -   $ lblTrackingNumberResult��$��1��$��2��$��20, 20, 0 ,0q�$��15(�$
��Bold"��� -   $ lblStatusResult��$��1��$��2��$��20, 50, 0 ,0q�$��15(�$
��Bold"��� -    $ lblDepartureHubResult��$��1��$��2��$��20, 80, 0 ,0q�$��15(�$
��Bold"��� -!   $ lblDestinationHubResult��$��1��$��2��$��20, 110, 0 ,0q�$��15(�$
��Bold"��� -"   $ lblCustomerIDResult��$��1��$��2��$��20, 140, 0 ,0q�$��15(�$
��Bold"��� -#   $ lblShipDateResult��$��1��$��2��$��20, 170, 0 ,0q�$��15(�$
��Bold"��� -$   $ lblLastUpdatedDateResult��$��1��$��2��$��20, 200, 0 ,0q�$��15(�$
��Bold"��� -%   $ lblDateDeliveredResult��$��1��$��2��$��20, 230, 0 ,0q�$��15(�$
��Bold"�� -&   $ findCustomerGrid�� �� $��* ��� $��* ��� $��* ��� $��50 �	 �� $��55 ��� $��70 ��� $��80 ��� �� $	��100 �.+�  -'   %  Name$% customerShipmentsDataGrid��$��3��$��2��$��2��$��15q�
���   �   $ Black��$ 8Q�$ Performance=� �� "  .���  � ��
 �  ����  � ��
 �������  � ��$ 5q� P�  �@J�IsMouseOver . . ���  � ��
 �������  � ��
 �  ��  -(   $% customerListDataGrid��$��3��$��2��$��2��$��2��$��15q�
���   �   $ Black��$ 8Q�$ Performance=� �� "  .���  � ��
 �  ����  � ��
 �������  � ��$ 5q� P�  �@J�IsMouseOver . . ���  � ��
 �������  � ��
 �  ���� $��2��$��2��
���   �$��50��$��
18,30,18,0q�$# 12��$$ 12���� $��2��$��2��$��2��
���   �$��50��$��
18,30,18,0q�$# 12��$$ 12���� $��Customer's Shipments��$��2��$��2��$��Center=�$��Center=�$��30(�$
��Bold"�
�������$��
15,30,15,0q��� $��Customer List��$��2��$��2��$��2��$��Center=�$��Center=�$��30(�$
��Bold"�
�������$��
15,30,15,0q��� $��Enter Customer ID:  ��$��1��$��Bottom=�$��Right=�$��26(�$
��Bold"��� -)   $ customerSearchTextBox��$��1��$��1��$��40��$	��400��$	��310��$��Bottom=�$��Center=�$��18(�$��8,0,0,0q�$! 6��