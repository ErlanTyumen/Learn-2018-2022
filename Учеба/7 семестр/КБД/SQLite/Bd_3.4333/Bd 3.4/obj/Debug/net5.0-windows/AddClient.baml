   M S B A M L   `   `   `  ����A  =Bd 3.4, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null!clr-namespace:Bd_3._4Bd_3._4  5   	       Bd_3._4.AddClient   5   	   \ XPresentationFramework, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   'localclr-namespace:Bd_3._4     5   	   -   5          � Title$  	AddClient��5   	   $	��199��6   $	��379��6(    � 	Resources 5	       	  Label �� 
TargetType �� BasedOn �� Property �� Value  CustTextBox��%�  &	        &	 �     �� 5
   
   " ��6    6:   Z� .�5      ��  � ��$
 Left=�64   �� 5       � ��$ Center=�62   �� 5       � ��$ 3q�6'   �� 5       � ��$ 23��6'   5      �� 5   
   " ��6$    6B   Z� .�5      ��  � ��$ Right=�64   �� 5       � ��$ Center=�62   �� 5       � ��$ 3q�6'   �� 5       � ��$ 26��6'   �� 5       � ��$	 120��6&   5      5      .��5      � $��1��6   $
��Left=�6   $	��Top=�63   $	��155��6L   $	��340��6Y   $��	10,10,0,0q�6e    � RowDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   .+�5    
   �� $��Name:��6   $��0��6    #��[  6-   �� 5!   
   -   5         ��Name$ nameTextBox��5!      $��0��6'   #��[ 64   ��5"      �� *Name+ �� Mode$ TwoWay=�	 �� NotifyOnValidationError$
	 true��
 �� ValidatesOnExceptions$

 true���� 5#   
   $��Second Name:��6   $��1��6'   #��[  64   �� 5$   
   -   5        $ secondNameTextBox��5$      $��1��6-   #��[ 6:   ��5%      �� *
SecondName+$ TwoWay=�$
	 true��$

 true���� 5&   
   $��Date of birthday:��6   $��2��6,   #��[  69   *  $System.Windows.Controls.DataGridCell  5'   
   -   5          Name$ DataGrid��5'      $��Right=�6)   $��2��6E   $��3q�6R   .��5(      (  "System.Windows.Controls.DatePicker  -   5          Name$ DatePickerBirthday��5(         SelectedDate 65   �� *DOB+$ TwoWay=�$
	 true��$

 true�� �� StringFormat$ D�� �� UpdateSourceTrigger$ PropertyChanged=�5)      �� 5*   
   -   5         ��Name$ Save_B��5*      $��Добавить��6!   $
��Left=�64   $��	10,10,0,0q�6O   $��3��6b   $	��Top=�6o   $	��160��6�   $��40��6�   6�   �� 5+   
   -   5        $ Cancel_B��5+      $��Отмена��6#   $
��Left=�64   $��
185,10,0,0q�6O   $��3��6c   $	��Top=�6p   $	��155��6�   $��40��6�   6�   5-      5.      