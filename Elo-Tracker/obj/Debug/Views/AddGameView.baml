   M S B A M L   `   `   `  ����F  BElo-Tracker, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5clr-namespace:Elo_Tracker.ViewsElo_Tracker.Views  5      7 clr-namespace:Elo_Tracker.ModelsElo_Tracker.Models  5      O Kmscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e0891&clr-namespace:System;assembly=mscorlibSystem 5	      #    Elo_Tracker.Views.AddGameView   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      1localclr-namespace:Elo_Tracker.Views     5      3models clr-namespace:Elo_Tracker.Models     5      9System&clr-namespace:System;assembly=mscorlib     5	      -   5          >�Name$  addGameView��5      .��5      �  � DataContext 6   ��  �� ElementName$ addGameView�� �� Path$ VM� � 	Resources 5   
    �� 
TargetType �� Property �� Value   winStateEnum S� 
MethodName	 S� 
ObjectType  System.Enum
 S� MethodParameters M� TypeName��%s  '��       '�� t     &	  �     �� 5      " ��6   .�5      ��  � ��$ Center=�68   �� 5       � ��$ Center=�66   5      �� 5      " ��6   .�5      ��  � ��$	 100��6*   �� 5       � ��$ 20��6+   5      S� 5      $ 	GetValues��66   "	  5   !   
 5      M� 5      $ models:GameWinState��6   5      5       � RowDefinitions 5   
   �� 5      $��30 �6   �� 5      �� 5       $��30 �6   �� 5!      �� 5"      $��30 �6    � ColumnDefinitions 5$   
   �� 5%      �� 5&      .+�5(   
   �� $��White Player��6   �� 5)   
   $��1��6    �� DisplayMemberPath$
 Name��5,      ��5*      �� *	Players+ �� SelectedItem 5+      �� *White+5,      �� 5.   
   $��1��6   $��Black Player��6$   �� 5/   
   $��1��6   $��1��6    $
 Name��52      ��50      �� *	Players+ 51      �� *Black+52      �� 54   
   $��2��6   $��2��6!   $��Winner��65   �� 55   
   $��3��6   $��2��6    ��56      ��  �� Source# [   57      �� *Winner+�� 59   
   $��4��6   $��2��6   $	��100��62   $��20��6>   $��Submit��6J   ��5:      �� *AddGameCommand+5<      5=      