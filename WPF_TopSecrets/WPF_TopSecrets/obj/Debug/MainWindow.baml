   M S B A M L   `   `   `  ����I  EWPF_TopSecrets, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null/clr-namespace:WPF_TopSecretsWPF_TopSecrets  5   	       WPF_TopSecrets.MainWindow   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   .localclr-namespace:WPF_TopSecrets     5   	   V RMaterialDesignThemes.Wpf, Version=3.1.1.1361, Culture=neutral, PublicKeyToken=nullFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5   	      MaterialDesignBody#���   5	   	   $��Regular"�5
   	   $��13(�5   	   &   System.Windows.Media.TextOptions    TextFormattingMode$  Ideal=�5   	      TextRenderingMode$
 Auto=�5   	     MaterialDesignPaper#���  5   	     MaterialDesignFont#���  5   	    � Title$ Top Secrets��5   	   $	��450��6   $	��800��6*   .��5      �  � ColumnDefinitions 5   
   �� 5      $��* �6   �� 5      $��* �6   �� 5      $��* �6   �� 5      $��* �6    � RowDefinitions 5   
   �� 5      $	��.6* �6   �� 5      $	��.4* �6   �� 5      $��* �6   �� 5      $��* �6   �� 5      $��* �6   .+�5    
   �� -   5        $��RegisterBtn��5!        MaterialDesignRaisedButton#��[ 5"      $	��150��5#      $��0��5$      .��5%   '   РЕЄСТРАЦІЯ5'      �� 5)   
   -   5        $��LoginBtn��5*      #��[ 5+      $	��150��5,      $��1��5-      .��5.   $   
ВХІД50      �� 52   
   -   5        $��ChangeProfileBtn��53      #��[ 54      $	��150��55      $��2��56      .��57   ,   ПРОФІЛЬ59      �� 5;   
   -   5        $��ChangePasswordBtn��5<      #��[ 5=      $	��150��5>      $��3��5?      .��5@   -   БЕЗПЕКА5B      �� 5D   
   -   5        $��AddSecretDataBtn��5E      #��[ 5F      $	��150��5G      $��3��5H      $��2��5I      .��5J   ,   ДОДАТИ ДАНІ5L      �� 5N   
   -   5        $��EditSecretDataBtn��5O      #��[ 5P      $	��150��5Q      $��3��5R      $��3��5S      .��5T   -   ЗМІНИТИ ДАНІ5V      �� 5X   
   -   5        $��DeleteSecretDataBtn��5Y      #��[ 5Z      $	��150��5[      $��3��5\      $��4��5]      .��5^   /   ВИДАЛИТИ ДАНІ5`      �� 5b   
   -   5        $��
HappyBlock��5b      ���#424242$��1��6;   $��4��6H    $  MaterialDesignHeadline5TextBlock#��[ 6\    �� TextAlignment$ Center=�6�   $��Center=�6�   5d      ]� 5f   
   $��0��5g      $��3��5h      $��2��5i      $��3��5j       � IsSharedSizeScope . $��10 20q�5l      .+�5m      �� $
��Auto=�6   .��5n      �� -	   5        $��SecretsData��5o      ��5q      �� 5r      .R�5s      ��  ��Name$ Border��6%    �� Padding$ 8q�65   ._�5t   "   �  5u   &   �� 5v   *   	 z� SharedSizeGroup$	 Checkerz��6;   �� 5w   *   .+�5y   &   �� $��Center=�6/   
 d� 	IsChecked
 6J   �� *
IsSelected+�� 5z   &   $��8 0 0 0q�61   $��1��6B   .+�5{   *   �� $
��Bold"�64   ��6F   �� *Description+�� 5}   *   ��5~   .   `� 5   2    �� StringFormat$ Сайт: {0}��6@   .1�5�   6   ��  �� Path$	 Url�6>   5�   3   5�   +   �� 5�   *   ��5�   .   `� 5�   2   $) #Логін: {0} | Пароль: {1}��6@   .1�5�   6   �� $ Login�6>   �� 5�   6   $ Password�6>   5�   3   5�   +   5�   '   5�   #   5�       �� Triggers 5�      �� 5�   "    �� Value$
 True��6M    �� Binding 6.   �� *
IsSelected+.a�5�   &   ��  �� 
TargetName$ Border��6-     MaterialDesignSelection �� Value# �  6W    �� Property � ��5�   #   5�      5�      5�      5�      5�      5�      