   M S B A M L   `   `   `  ����C  ?WPWS_EVE, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null!clr-namespace:WpfApp1WpfApp1  5   	   7 clr-namespace:WpfApp1.PropertiesWpfApp1.Properties  5   	       WpfApp1.MainWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   'localclr-namespace:WpfApp1     5   	   X TXceed.Wpf.Toolkit, Version=3.0.0.0, Culture=neutral, PublicKeyToken=3e4669d2f30244f44xctk)http://schemas.xceed.com/wpf/xaml/toolkit  5   	   .setting clr-namespace:WpfApp1.Properties  5   	     � Title$7  1Vin65 Integrator App - Willow Park Wine & Spirits��5   	   $	��550��6G   $	��550��6T   $	��825��6d    � Icon$ /Images/sync.ico��5   	    � ShowInTaskbar .   � WindowStartupLocation$ CenterScreen=�5   	   .��5      � .+�5   
   ��  �� Orientation$ Vertical=�6   .+�5      � .+�5      �� $ 
Horizontal=�6   ��66   �� !  WpfApp1.Properties.Settings   Default �� Source# Z  �� Path$ ColorSecondary� �� Mode$ OneWay=�.+�5      �� $��VIN65��6   $
��Auto��6,   $��24(�69   5      �� 5      $ 
Horizontal=�6   $��Right=�66   .+�5      �� -   5        	 ��Name$	 btnToEpicor��5      
 � ToolTip$.
 (Click to switch between VIN65 and Epicor��6L   $��14(�6   $��Go to Epicor��6�   $��Center=�6�   $
��Auto��6�   $
��Auto��6�   $��	12,0,12,0q�6�   $��	20,4,20,4q�6�   5      5      �� 5      .@�5      �� $��Query��6   .��5       �� $ Vertical=�6!   $��2q�68   $	��500��6�   ��6C   �� # Z $ ColorPrimary�$ OneWay=�.+�5!      �� $��Product Query��6    $
��Auto��6�   $��18(�6�   ��68   �� # Z $ ColorPrimary�$ OneWay=�6�   	� 5"      -   5         	�Name$ radQueryProductAll��5"   &    d� 	IsChecked$
 TrueY�6B    	� 	GroupName$ group��6S   $��All Products��6e   $��14(�6|   $��12q�6�   �� 5#      $ 
Horizontal=�6%   .+�5$      	� -   5        $ radQueryProductSku��5$   *   $ FalseY�6F   $ group��6�   $	��SKU��6�   $��14(�6�   $��12q�6�   �� 5%      -   5         ��Name$ txtQuerySku��5%   &   $y�Visible=�6;    �� TextAlignment$ Center=�6P   $��50��6g   $
��Auto��6u   $��	12,8,12,8q�6�   $��4q�6�   .��6�   7392426�   5&      �� 5'      $ 
Horizontal=�6%   .+�5(      �� -   5        $	 btnQuery��5(   %   $4
 .Click to run a query (see XML tab for results)��67   $��14(�6p   $��	Run Query��6~   $
��Left=�6�   $
��Auto��6�   $
��Auto��6�   $��4q�6�   $��12q�6�   �� 5)      -   5         ��Name$ txtQuerySuccess��5)   (   $(��"         Query Successful         ��6A   $y�Hidden=�6k   ���#00B21C$��Center=�6�    �� TextAlignment$ Center=�6�   $��Center=�6�   $
��Auto��6�   $
��Auto��6�    �� Padding$ 4q�6�   $��18(�6
  5*      5,      5-      �� 5/      $	��XML��6   .��50      � .+�51      �� $ Vertical=�6%   $��2q�6<   ��6G   �� # Z $ ColorPrimary�$ OneWay=�.+�52      �� $ 
Horizontal=�6)   .+�53   "   �� $	��XML��6(   $
��Auto��6�   $��18(�6�   ��66   �� # Z $ ColorPrimary�$ OneWay=�6�   �� 54   "   -   5        $	 
btnXmlSave��54   )   $$
 Save the XML results to a file��6=   $��14(�6f   $
��Save��6t   $
��Left=�6�   $
��Auto��6�   $
��Auto��6�   $��4q�6�   $��	12,4,12,4q�6�   �� 55   "   -   5        $	 btnXmlReset��55   )   $$
 Click to clear the XML results��6>   $��14(�6g   $��Reset��6u   $
��Left=�6�   $
��Auto��6�   $
��Auto��6�   $��4q�6�   $��	12,4,12,4q�6�   56      �� 57      -	   5        $ txtVin65Xml��57   &   $	��400��6;   $	��200��6K   $	��800��6X   $
��Auto��6g    �� TextWrapping$
 Wrap=�58   "    �� AcceptsReturn . $��Visible=�6K   $��Visible=�59   %   ��57   t   �� # Z $ ColorSecondary�$ OneWay=�59   %   5:      5;      5=      �� 5?      $��Settings��6   .��5@      �� $ Vertical=�6!   $��2q�68   ��6C   �� # Z $ ColorPrimary�$ OneWay=�.+�5A      �� $��Settings��6    $
��Auto��6�   $��18(�6�   ��63   �� # Z $ ColorPrimary�$ OneWay=�6�   �� 5B      -
   5         ��Name$ lblNotification��5B       $�� ��69   $��12(�6�   ��6D   �� # Z $ ColorPrimary�$ OneWay=�6�   �� 5C      $ 
Horizontal=�6%   .+�5D      �� $��	Username:��6$   $��14(�68   $��2q�6F   �� 5E      -   5        $ txtUsername��5E   &   {�.  $S
 MUsername to access the VIN65 API (*** MUST MATCH THE WEB SERVICE ACCOUNT ***)��6M   $��Center=�6�   $
��Auto��6�   $��3q�6�   .��6�   DeanJonesSANDBOX6�   5F      �� 5G      $ 
Horizontal=�6%   .+�5H      �� $��	Password:��6$   $��14(�68   $��2q�6F   �� 5I      -   5        $ txtPassword��5I   &   {�.  $S
 MPassword to access the VIN65 API (*** MUST MATCH THE WEB SERVICE ACCOUNT ***)��6M   $��Center=�6�   $
��Auto��6�   $��3q�6�   .��6�   
willowpark6�   5J      �� 5L      $��20��6$   $
��Auto��60   ��6=   �� # Z $ ColorPrimary�$ OneWay=�6�   �� 5M      $ 
Horizontal=�6%   .+�5N      �� $��	XML Path:��6$   $��14(�68   $��2q�6F   �� 5O      -   5        $ 
txtXmlPath��5O   &   {�.  $��Center=�6L   $	��200��6g   $
��Auto��6v   $��3q�6�   .��6�   
C:\_temp6�   �� 5P      -   5        $	 
btnXmlPath��5P   %   $E
 ?Click to change the XML folder path (where XML files are saved)��69   $	��...��6�   $��14(�6�   $��40��6�   $��25��6�   $��2q�6�   5Q      �� 5S      $��6��6$   $
��Auto��6/   ��6<   �� # Z $ ColorPrimary�$ OneWay=�6�   �� 5T      $'��!Select what fields to be updated?��6    $��14(�6L   $��2q�6Z   �� 5U      $ 
Horizontal=�6%   .+�5V      �� $��20��6$   64   	� 5W      -   5        $ radProducts��5W   *   $ group2��6?   $��Products��6R   $��14(�6e   $��2q�6s   5X      �� 5Y      $ 
Horizontal=�6%   .+�5Z      �� $��20��6$   64   	� 5[      -   5        $ radInventory��5[   *   $ group2��6@   $��	Inventory��6S   $��14(�6g   $��2q�6u   5\      �� 5]      $ 
Horizontal=�6%   .+�5^      �� $��20��6$   64   	� 5_      -   5        $ radSales��5_   *   $ group2��6<   $��Sales��6O   $��14(�6_   $��2q�6m   5`      �� 5b      $��6��6$   $
��Auto��6/   ��6<   �� # Z $ ColorPrimary�$ OneWay=�6�   �� 5d      $ 
Horizontal=�6%   .+�5e      �� $��Select time for updates?��6$   $��14(�6G   $��2q�6U   "  Xceed.Wpf.Toolkit.TimePicker  5f      {�.    	StartTime$ 00:00:00h�6?      TimeInterval$ 00:30:00h�6T   $
��Left=�6l   $��2q�6�   $��60��6�   $	��120��6�   $��14(�6�   ,  &Xceed.Wpf.Toolkit.Primitives.InputBase   AllowTextInput .  6�   5g      �� 5h      $ 
Horizontal=�6%   .+�5i      �� -   5        $	 btnSettingsEdit��5i   %   $y�Visible=�6>   $+
 %Click to make changes to the settings��5j   %   $��14(�6U   $
��Edit��6c   $
��Left=�5k   C   $
��Auto��6^   $
��Auto��6k   $��4q�6y   $��12q�6�   �� 5l      -   5        $	 btnSettingsSave��5l   %   $y�Hidden=�6>   $/
 )Click to save the changes to the settings��5m   %   $��14(�6Y   $
��Save��6g   $
��Left=�5n   C   $
��Auto��6^   $
��Auto��6k   $��4q�6y   $��12q�6�   �� 5o      -   5        $	 btnSettingsCancel��5o   %   $y�Hidden=�6A   $!
 Click to cancel the changes��5p   %   $��14(�6K   $��Cancel��6Y   $
��Left=�5q   E   $
��Auto��6`   $
��Auto��6m   $��4q�6{   $��12q�6�   5s      5t      5u      5v      5w      5x      5y      