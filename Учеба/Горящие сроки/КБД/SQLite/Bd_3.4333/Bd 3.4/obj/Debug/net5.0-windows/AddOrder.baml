   M S B A M L   `   `   `  ����A  =Bd 3.4, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null!clr-namespace:Bd_3._4Bd_3._4  5   	       Bd_3._4.AddOrder   5   	   \ XPresentationFramework, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   'localclr-namespace:Bd_3._4     5   	   -   5          � Title$  AddOrder��5   	   $	��274��6   $	��389��6'    � 	Resources 5	       	  Label �� 
TargetType �� BasedOn �� Property �� Value  CustTextBox��%�  &	        &	 �     �� 5
   
   " ��6    6:   Z� .�5      ��  � ��$
 Left=�64   �� 5       � ��$ Center=�62   �� 5       � ��$ 3q�6'   �� 5       � ��$ 23��6'   5      �� 5   
   " ��6$    6B   Z� .�5      ��  � ��$ Right=�64   �� 5       � ��$ Center=�62   �� 5       � ��$ 3q�6'   �� 5       � ��$ 26��6'   �� 5       � ��$	 120��6&   5      5      .��5      � $��1��6   $
��Left=�6   $	��Top=�63   $	��235��6L   $	��360��6Y   $��	10,10,0,0q�6e    � RowDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5       $
��Auto �6   �� 5!      $
��Auto �6   .+�5#   
   �� $��Room id:��6   $��0��6#   #��[  60   �� 5$   
   -   5         ��Name$ RoomIdTextBox��5$      $��0��6)   #��[ 66   ��5%      �� *RoomId+ �� Mode$ TwoWay=�	 �� NotifyOnValidationError$
	 true��
 �� ValidatesOnExceptions$

 true���� 5&   
   $��Arrival:��6   $��2��6#   #��[  60   *  $System.Windows.Controls.DataGridCell  5'   
   -   5          Name$ ArrivalDatePicker��5'      $��Right=�62   $��2��6N   $��3q�6[   .��5(      (  "System.Windows.Controls.DatePicker  -   5          Name$ ArrivalDate��5(         SelectedDate 6.   �� *	Arrival+$ TwoWay=�$
	 true��$

 true�� �� StringFormat$ D�� �� UpdateSourceTrigger$ PropertyChanged=�5)      �� 5*   
   $��
Departure:��6   $��3��6%   #��[  62     5+   
   -   5        $ DepartureDatePicker��5+      $��Right=�64   $��3��6P   $��3q�6]   .��5,        -   5        $ DepartureDate��5,       60   �� *	Departure+$ TwoWay=�$
	 true��$

 true��$ D��$ PropertyChanged=�5-      �� 5.   
   -   5         ��Name$ 	is_Active��5.      $��IsActive��6&   $
��Left=�69   $��3,0,0,0q�6T   $��4��6e   $	��Top=�6r   �� 5/   
   $��Date Of Booking:��6   $��5��6+   #��[  68     50   
   -   5        $ BookingDatePicker��50      $��Right=�62   $��5��6N   $��3q�6[   .��51        -	   5        $ BookingDate��51       6.   �� *DateOfBooking+$ TwoWay=�$
	 true��$

 true��$ D��$ PropertyChanged=�52      �� 53   
   $
��Sum:��6   $��6��6   $	��Top=�6,   #��[  6D   �� 54   
   -
   5        $ 
SumTextBox��54      $��7��6&   $	��Top=�63   #��[ 6K   ��55      �� *Sum+$ TwoWay=�$
	 true��$

 true���� 56   
   -   5         ��Name$ Save_B��56      $��Добавить��6!   $��Bottom=�64   $
��Left=�6P   $��	3,0,0,-43q�6k   $��6��6~   $	��160��6�   $��40��6�   6�   �� 57   
   -   5        $ Cancel_B��57      $��Отмена��6#   $��Bottom=�64   $��Right=�6O   $��	0,0,3,-43q�6k   $��6��6~   $	��155��6�   $��40��6�   6�   59      5:      