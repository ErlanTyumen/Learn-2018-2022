   M S B A M L   `   `   `  ����A  =Bd 3.4, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null!clr-namespace:Bd_3._4Bd_3._4  5   	       Bd_3._4.MainWindow   5   	   \ XPresentationFramework, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   'localclr-namespace:Bd_3._4     5   	   -   5          � Title$  Clients_Orders��5   	   $	��588��6    $	��788��6-    � 	Resources 5	         clientsViewSource  clientsOrdersViewSource �� Source �� Source 	 Label �� 
TargetType �� BasedOn �� Property �� Value  CustTextBox��%#  &	        &	      7   &	 C     &	 
    �� 5
   
   6   �� 5   
    5      �� *Orders+8   �� 5   
   " ��6    6:   Z� .�5      ��  � ��$
 Left=�64   �� 5       � ��$ Center=�62   �� 5       � ��$ 3q�6'   �� 5       � ��$ 23��6'   5      �� 5   
   " ��6$    6B   Z� .�5      ��  � ��$ Right=�64   �� 5       � ��$ Center=�62   �� 5       � ��$ 3q�6'   �� 5       � ��$ 26��6'   �� 5       � ��$	 120��6&   5      5      .��5      � .+�5   
   � -   5         �Name$ ExistingClients��5      .+�5      �� -   5        	 ��Name$	 	addClient��5      $��Добавить��6(   $
��Left=�6;   $��	10,10,0,0q�6V   $��2��6i   $	��Top=�6v   $	��105��6�   $��40��6�   6�   �� 5      -   5        $	 updateClient��5      $��Обновить��6+   $
��Left=�6>   $��
120,10,0,0q�6Y   $��2��6m   $	��Top=�6z   $	��105��6�   $��40��6�   6�   �� 5       -   5        $	 deleteClient��5       $��Удалить��6+   $
��Left=�6=   $��
230,10,0,0q�6X   $	��Top=�6l   $	��105��6�   $��40��6�   6�   &   System.Windows.Controls.DataGrid  5!      -   5        
  Name$
 clientDataGrid��5!         AutoGenerateColumns$ False��6/   $��10,55,10,295.8q�5#         RowDetailsVisibilityMode$ VisibleWhenSelected=�6/      CanUserAddRows$ False��6^   ��5"      �� # [     Columns 5%      0  *System.Windows.Controls.DataGridTextColumn  5&      -   5        clientIdColumn��,  &System.Windows.Controls.DataGridColumn   Header$ Category Id��5'   !      Width5  /System.Windows.Controls.DataGridLengthConverter$ SizeToHeader 66      
IsReadOnly$
 True��5(   !   1  +System.Windows.Controls.DataGridBoundColumn   Binding 5&   A   �� *
ClientId+5(   !     5)      -   5        firstNameColumn��$
 Name��5)   [   $ * 5*   !    5)   B   �� *Name+5*   !     5+      -	   5        secondNameColumn��$ Second Name��5+   b   $ * 5,   !    5+   C   �� *
SecondName+5,   !   4  .System.Windows.Controls.DataGridTemplateColumn  5-      -
   5        	dobColumn��$ Birthday��5-   @   $ * 6R      CellTemplate 5.      �� 5/      .R�50   "   (  "System.Windows.Controls.DatePicker     SelectedDate 6-   �� *Dob+ �� Mode$ TwoWay=� �� NotifyOnValidationError$
 true�� �� ValidatesOnExceptions$
 true�� �� StringFormat$ D�� �� UpdateSourceTrigger$ PropertyChanged=�51      53      55      56      � 57   
   -   5        $ 	NewClient��57      $��1��6"   $
��Left=�6/   $	��Top=�6J   $y�	Collapsed=�6�   
����d� � DataContext 6c   ��  �� RelativeSource �� *FindAncestor+ �� AncestorType" � �� Path$ 	newClient�$ Explicit=�59      � 5:   
   -   5        $ ExistingOrders��5:      .+�5;      �� -   5        $	 addOrder��5;      $��Добавить��6'   $
��Left=�6:   $��
10,281,0,0q�6U   $	��Top=�6i   $	��105��6�   $��45��6�   6�   �� 5<      -   5        $	 updateOrder��5<      $��Обновить��6*   $
��Left=�6=   $��120,281,0,0q�6X   $	��Top=�6m   $	��105��6�   $��45��6�   6�   �� 5=      -   5        $	 deleteOrder��5=      $��Удалить��6*   $
��Left=�6<   $��230,281,0,0q�6W   $	��Top=�6l   $	��106��6�   $��45��6�   6�     5>      -   5        $
 orderDataGrid��5>      $ False��6.      EnableRowVirtualization$
 True��5?      $ False��5A      $��10,331,10,20q�5B      $ VisibleWhenSelected=�6-   ��5@      �� # [  5C        5D      -   5        orderIdColumn��$ Order Id��5D   \   $ SizeToHeader 6n   $
 True��6�    6@   �� *	OrderId+6�     5E      -   5        clientIdColumn1��$ 	Client Id��5E   _   $
 True��6r   $ SizeToHeader 6�      
Visibility$ 	Collapsed=�6�    6B   �� *
ClientId+6�     5F      -   5        roomIdColum��$ Room Id��5F   Z   $ SizeToHeader 6k    6>   �� *RoomId+6k     5H      -   5        arrivalColumn��$ Arrival��5H   D   $ * 6U    5I      �� 5J      .R�5K   "      6-   �� *	Arrival+$ TwoWay=�$
 true��$
 true��$ D��$ PropertyChanged=�5L      5N        5O      -   5        departureColumn��$ 	Departure��5O   F   $ * 6Y    5P      �� 5Q      .R�5R   "      6-   �� *	Departure+$ TwoWay=�$
 true��$
 true��$ D��$ PropertyChanged=�5S      5U      4  .System.Windows.Controls.DataGridCheckBoxColumn  5V      -   5        isActiveColumn��$ 	Is Active��5V   b   $ SizeToHeader 6u    6E   �� *
IsActive+6u     5W      -   5        dateOfBookingColumn��$ Date Of Booking��5W   J   $ * 6c    5X      �� 5Y      .R�5Z   "      6-   �� *DateOfBooking+$ TwoWay=�$
 true��$
 true��$ D��$ PropertyChanged=�5[      5]        5^      -   5        	sumColumn��$	 Sum��5^   T   $ * 6a    6<   �� *Sum+6a   5`      5a      5b      5c      