   M S B A M L   `   `   `  ����  Ocynkownia0811%    Ocynkownia0811.panelXCynkowanie   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   U QMaterialDesignThemes.Wpf, Version=2.6.0.325, Culture=neutral, PublicKeyToken=nullFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5   	     � Title$  panelCynkowanie��5   	   $	��700��6!   $
��1300��6.    � WindowStartupLocation$ CenterScreen=�6;   .��5	      � 
�������.+�5
   
   � -   5        $��pCynkowanie1��5
       � RowDefinitions 5      �� 5      $��60 �6    �� 5      $
��0.1* �6    �� 5      �� 5      $��60 �6    .+�5      � $��0��6   
�����F�$��2��67    � ColumnDefinitions 5      �� 5      $��1* �6'   �� 5      �� 5      $��0.25* �6'    5      �� 5      $
��0.5* �6$   �� 5      $��0.75* �6$   .+�5      �� $��Panel CYNKOWANIE��6   $��23(�64   $��0��6B   $��0��6R   
�������$��Center=�6r   $
��Left=�6�    J� Opacity$	 0.8Q�6�   $
��10,0q�6�   �� 5      $1��+Wybór zaformowanej trawersy do ocynkowania��6   $��15(�6N   $��0��6\   $��1��6l   
�������$��Center=�6�   $
��Left=�6�   $	 0.8Q�6�   $
��10,0q�6�   5      � 5!      $��1��6    5"      �� 5#      $��3* �6'   �� 5$      .+�5&      �� -   5        $��cyn_szukajka��5&      $��0��6.   $
��20,0q�6>   )  #MaterialDesignThemes.Wpf.HintAssist   Hint$ fraza szukana��6L    %  !MaterialDesignFloatingHintTextBox#��[  6|   6�   �� 5'       �� Orientation$ 
Horizontal=�6   $��1��66   $
��20,0q�6F   $��Center=�6T   $��Bottom=�6q   .+�5(      �� -   5        $��cyn_szukajProtokol��5(      $��1��67    � ToolTip$8 2Przeszukaj bazę protokołów pod kątem kryterium��6t   $��60��6�   $��0,0,40,0q�6�   ��6G   0  *MaterialDesignThemes.Wpf.PackIconExtension  *	Magnify+6�   �� 5)      -   5        $!��cyn_resetujSzukajkeProtokol��5)      $��1��6@   $$ Zresetuj szukanie protokołów��6|   $��60��6�   $��40,0,0,0q�6�   ��6P     *	Refresh+6�   5*      5+      � 5.      $��2��6   .+�5/      &   System.Windows.Controls.DataGrid  -   5        $��dgWyborTrawersy��5/      $��20,20q�62   $	��400��6A   $��Stretch=�6Q      AutoGenerateColumns .  	   
IsReadOnly	 . 
   SelectionUnit$
 FullRow=�6�   $��Stretch=�6�      	RowHeight$ 40Q�6�   ��6m   ��    Columns 50      0  *System.Windows.Controls.DataGridTextColumn  51      ,  &System.Windows.Controls.DataGridColumn   Header$ nr dnia��6-   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6>   �� *nrDnia+  52      $ nr trawersy��6-    6C   �� *
nrTrawersy+  53      $ data formowania��6-    6G   �� *dataStopFormowanie+ �� StringFormat$ 
dd.MM.yyyy��  54      $ godzina formowania��6-    6J   �� *godzinaStopFormowanie+58      59      � 5:      $��3��6   .+�5;      � .+�5<      � 
����İ� 5=      �� 5>      �� 5?      �� 5@       5B      �� 5C      $
��Auto �6,   .+�5I      �� -   5        $&�� przejdzDoSzczegolowCynkowaniaBTN��5I   !   $��50��6J   $��2��6V    " MaterialDesignRaisedDarkButton#��[ 5J      $	��210��6@   $��20,0,0,0q�6L   $# Wprowadź dane do bazy danych��6a   .��5K      �� $ 
Horizontal=�6)   .+�5L   "   �� $��Szczegóły cynkowania��6,   '  !MaterialDesignThemes.Wpf.PackIcon  5M   "   �  �ControlzEx.PackIconBase`1[[MaterialDesignThemes.Wpf.PackIconKind, MaterialDesignThemes.Wpf, Version=2.6.0.325, Culture=neutral, PublicKeyToken=null]]   Kind$	 Cup=�6:   $��	10,0,15,0q�6E   $��Bottom=�6X   $��20��6s   $��20��6~   5O      5P      5S      5T      5U      5W      � 5X   
   -   5        $��pCynkowanie2��5X       5Z      �� 5[      $��60 �6$   �� 5\      �� 5^      $��60 �6$   .+�5b      � $��0��6   
�����F�$��2��67    5c      �� 5d      $��1* �6'   �� 5e      �� 5f      $��0.25* �6'    5h      �� 5i      $
��0.5* �6$   �� 5j      $��0.75* �6$   .+�5l      �� $��Panel CYNKOWANIE��6   $��23(�64   $��0��6B   $��0��6R   
�������$��Center=�6r   $
��Left=�6�   $	 0.8Q�6�   $
��10,0q�6�   �� 5m      $,��&Uzupełnienie szczegółów cynkowania��6   $��15(�6F   $��0��6T   $��1��6d   
�������$��Center=�6�   $
��Left=�6�   $	 0.8Q�6�   $
��10,0q�6�   5n      � 5p      $��1��6    5q      �� 5r      �� 5s      �� 5t      �� 5u      �� 5v      �� 5w      �� 5x      �� 5y       5|      �� 5}      �� 5~      .+�5�      �� $ 
Horizontal=�6   $��2��66   $��Center=�6C   .+�5�      �  5�      �� 5�      �� 5�      .+�5�      (	  "System.Windows.Controls.DatePicker	  -   5        $��poleDataStartCynkowanie��5�   7    � Language$ pl-PL�6%   $
��40,0q�6V   $��0��6d   $ data startu cynkowania��6t   $��Bottom=�6�   $	��200��6�   )
  #MaterialDesignThemes.Wpf.TimePicker
  5�      -	   5        $ ��poleGodzinaStartCynkowanie��5�   4   $
��40,0q�6V    
  	Is24Hours . $��Bottom=�6u   $��1��6�    ( $MaterialDesignFloatingHintTimePicker#��[ 6�   $	��200��6�   $ godzina startu cynkowania��6�   5�      5�      �� 5�      $ 
Horizontal=�6   $��3��66   $��Center=�6C   .+�5�      �  5�      �� 5�      �� 5�      .+�5�      	  -
   5        $��poleDataStopCynkowanie��5�   7   $ pl-PL�6%   $
��40,0q�6U   $��0��6c   $" data zakończenia cynkowania��6s   $��Bottom=�6�   $	��200��6�   
  5�      -   5        $��poleGodzinaStopCynkowanie��5�   4   $
��40,0q�6U    . $��Bottom=�6t   $��1��6�   #��[ 6�   $	��200��6�   $% godzina zakończenia cynkowania��6�   5�      5�      �� 5�      -   5        $��poleNrTrawersy��5�   "   $��0��68   $��0��6E    ( $MaterialDesignFilledTextFieldTextBox#��[ 6U   $��Center=�6�   $
��20,0q�6�    �� AcceptsReturn .  �� TextWrapping$
 Wrap=�6�   $ numer wybranej trawersy��6�   {�.  6*  �� 5�      -   5        $��
poleNrDnia��5�      $��1��6.   $��0��6;   #��[ 6K   $��Center=�6�   $
��20,0q�6�    . $
 Wrap=�6�   $" numer dnia wybranej trawersy��6�   {�.  6#  �� 5�      -   5        $��poleTemperatura��5�      $��4��63   $��0��6@   #��[  6P   $��Center=�6�   $��20,10q�6�    . $
 Wrap=�6�   $ temperatura ocynku��6�   �� 5�      -   5        $��poleWagaPoOcynku��5�      $��5��64   $��0��6A   #��[  6Q   $��Center=�6�   $��20,10q�6�    . $
 Wrap=�6�   $ waga po cynkowaniu��6�   �� 5�      -   5        $"��poleKtoZatwierdzilCynkowanie��5�      $��6��6@   $��0��6M   #��[  6]   $��Center=�6�   $��20,10q�6�    . $
 Wrap=�6�   $! kto zatwierdził cynkowanie��6�   �� 5�      $ 
Horizontal=�6   $��Right=�66   $��7��6S   $
��10,0q�6`   .+�5�      �� -   5        $��txPotwierdzenie��5�   E   $#��Potwierdzam wprowadzone dane:��6    $��12(�6\   
���   �$��SemiBold"�6}   $	 0.7Q�6�   $��2q�6�   �� 5�      -   5        $��potwierdzenieCHK��5�      $ wybór tak/nie��67   $��Center=�6f    & "MaterialDesignFloatingHintComboBox#��[ 6�    �� SelectedValuePath$ Content��6�   .@�5�      �� .��6'   TAK6,   �� 5�      .��6'   NIE6,   5�      5�      �� 5�      -   5        $��txNaTrawersie��5�   ;   $��Materiały na trawersie:��6   $��2��6P   $��14(�6`   
���   �$��SemiBold"�6�   $	 0.7Q�6�   $��2q�6�   $��Bottom=�6�   � 5�      $��1��6   $��1��6'   $��6��64   .+�5�        -   5        $��dgNaTrawersie��5�      $��20,20q�64   $	��400��6C   $��Stretch=�6S    .  	 . $
 FullRow=�6�   $��Stretch=�6�   $ 40Q�6�   ��6o   ��  5�        5�      $ nr protokołu��61    6H   �� *nrProtokolu+  5�      $ nazwa��61    6@   �� *nazwa+  5�      $
 waga��61    6@   �� *waga+  5�      $ ilosc��61    6A   �� *ilosc+5�      5�      5�      � 5�      $��2��6   .+�5�      � .+�5�      � 
����İ� 5�      �� 5�      �� 5�      �� 5�       5�      �� 5�      $
��Auto �6,   .+�5�      �� -   5        $��wprowadzOcynkDoBazyBTN��5�   !   $��50��6@   $��2��6L   #��[ 5�      $	��210��6@   $��20,0,0,0q�6L   $# Wprowadź dane do bazy danych��6a   .��5�      �� $ 
Horizontal=�6)   .+�5�   "   �� $��Zatwierdź ocynkowanie��6,     5�   "   $ Check=�6:   $��	10,0,15,0q�6G   $��Bottom=�6Z   $��20��6u   $��20��6�   5�      5�      �� 5�      -   5        $��cofnijDoWyboruOcynk��5�   !   $��50��6=   $��0��6I   #��[ 5�      $	��210��6@   $��20,0,0,0q�6L   $# Wprowadź dane do bazy danych��6a   .��5�      �� $ 
Horizontal=�6)   .+�5�   "     $ ArrowLeftBold=�6:   $��	10,0,15,0q�6O   $��Bottom=�6b   $��20��6}   $��20��6�   �� 5�   "   $��Cofnij do wyboru��6,   5�      5�      5�      5�      5�      5�      5�      5�      