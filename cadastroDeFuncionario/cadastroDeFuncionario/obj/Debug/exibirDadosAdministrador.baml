   M S B A M L   `   `   `  ����  cadastroDeFuncionario4    .cadastroDeFuncionario.exibirDadosAdministrador   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	     � Title$  Exibir administrador��5   	   $��492.299��6&   $��561.082��67   $��Segoe Print)�6G    � 
ResizeMode$ CanMinimize=�6`   ��5      �� 5   
    �� EndPoint$ 0.5,1&�6    �� 
StartPoint$ 0.5,0&�6/   .��5      �  � Color$ 	#FF931F1F��6    � Offset$ 0.096Q�6-   � 5      $ White��6   $ 0.096Q�6)   5	      .��5      � $��0,0,0,1q�6   .+�5   
   �� $D��>O asterisco (*) significa que é obrigatório o preenchimento.��6   $
��Left=�6W   $��14,7,0,0q�6r   $	��Top=�6�   $��Arial)�6�   �� 5   
   $��Dados pessoais��6   $
��Left=�6)   $��235,132,0,0q�6D   $	��Top=�6Y   $
��Bold"�6q   $��Arial)�6�   �� 5   
   -   5        $��TextBoxNome��5      $
��Left=�6%   $��23��6@   $��123,180,0,0q�6L    �� TextWrapping$
 Wrap=�6a   $	��Top=�6u   $	��336��6�   $��Arial)�6�   {�.  6�   �� 5   
   $��Nome * :��6   $
��Left=�6#   $��
34,175,0,0q�6>   $	��Top=�6R   $
��Bold"�6j   $��Arial)�6|   �� 5   
   -   5        $��TextBoxEmail��5      $
��Left=�6&   $��23��6A   $��123,221,0,0q�6M   $
 Wrap=�6b   $	��Top=�6v   $	��336��6�   $��Arial)�6�   {�.  6�   �� 5   
   $��	Email * :��6   $
��Left=�6$   $��
34,219,0,0q�6?   $	��Top=�6S   $
��Bold"�6k   $��Arial)�6}   �� 5   
   $��Autenticação��6   $
��Left=�6'   $��244,255,0,0q�6B   $	��Top=�6W   $
��Bold"�6o   $��Arial)�6�   �� 5   
   $��	Login * :��6   $
��Left=�6$   $��
34,295,0,0q�6?   $	��Top=�6S   $
��Bold"�6k   $��Arial)�6}   �� 5   
   -   5        $��TextBoxLogin��5      $
��Left=�6&   $��23��6A   $��123,297,0,0q�6M   $
 Wrap=�6b   $	��Top=�6v   $	��336��6�   $��Arial)�6�   {�.  6�   �� 5   
   $��	Senha * :��6   $
��Left=�6$   $��
34,341,0,0q�6?   $	��Top=�6S   $
��Bold"�6k   $��Arial)�6}   �� 5   
   -   5        $��TextBoxSenha��5      $
��Left=�6&   $��23��6A   $��123,341,0,0q�6M   $
 Wrap=�6b   $	��Top=�6v   $	��336��6�   $��Arial)�6�   $��
��6�   {�.  6�   �� 5   
   $"��Digite novamente a senha * :��6   $
��Left=�67   $��
34,377,0,0q�6R   $	��Top=�6f   $
��Bold"�6~   $��Arial)�6�   �� 5   
   -   5        $"��TextBoxDigiteNovamenteASenha��5      $
��Left=�66   $��23��6Q   $��218,382,0,0q�6]   $
 Wrap=�6r   $	��Top=�6�   $	��241��6�   $��Arial)�6�   {�.  6�   �� 5   
   -   5         ��Name$ ButtonEditar��5   "    � ToolTip$ Editar��6   
������ 
������ $
��Left=�6k   $��
129,60,0,0q�6�   $	��Top=�6�   $��60��6�   $��53��6�   .��5      �� $��37��6   $��edit.ico��6    $
��Fill=�62   $��49��6A   5      �� 5   
   -   5        $ ButtonDeletar��5   #   $ Deletar��6   
������ $
��Left=�6S   $��
205,60,0,0q�6n   $	��Top=�6�   $��60��6�   $��53��6�   
������ .��5      �� $��33��6   $��
delete.ico��6    $
��Fill=�64   $��37��6C   5      �� 5   
   -   5        $ ButtonConfirmar��5      $ 	Confirmar��6*   
������ 
������ $
��Left=�6q   $��
282,58,0,0q�6�   $	��Top=�6�   $��60��6�   $��53��6�   {�.  .��5       �� $��40��6   $��	apply.ico��6    $
��Fill=�63   $��37��6B   5!      �� 5"   
   -	   5        $ ButtonVoltar��5"      $ Voltar��6'   
������ 
������ $
��Left=�6k   $��
359,59,0,0q�6�   $	��Top=�6�   $��60��6�   $��53��6�   .��5#      �� $��46��6   $��back.ico��6    $
��Fill=�62   $��55��6A   5$      �� 5%   
   $��Data registrado: ��6   $
��Left=�6,   $��
34,421,0,0q�6G   $	��Top=�6[   $
��Bold"�6s   $��Arial)�6�   �� 5&   
   -
   5        $��TextBoxDataRegistrado��5&      $
��Left=�6/   $��23��6J   $��147,425,0,0q�6V   $
 Wrap=�6k   $��
��6   $	��Top=�6�   $	��140��6�   $��Arial)�6�   {�.  6�   �� 5'   
   -   5        $��bloquearAdministrador��5'      $��Bloquear��6.   $
��Left=�6A   $��
440,50,0,0q�6\   $	��Top=�6p   $	��101��6�   $��Arial)�6�   $��25��6�   �� 5(   
   -   5        $"��imagemAdministradorBloqueado��5(      $
��Left=�64   $��52��6O   $��
462,80,0,0q�6[   $	��Top=�6o   $��65��6�   $��Circle_Red.ico��6�   $y�Hidden=�6�   �� 5)   
   -   5        $��imagemAdministradorAtivo��5)      $
��Left=�60   $��52��6K   $��461,80,-6,0q�6W   $	��Top=�6l   $	��100��6�   $��Circle_Green.ico��6�   5+      5,      