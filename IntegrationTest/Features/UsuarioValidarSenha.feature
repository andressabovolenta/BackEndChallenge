Funcionalidade: UsuarioValidarSenha
	Testes integrados do método de validação de senhas do usuário

Esquema do Cenário: Validação de senhas
	Dado que o host é 'https://localhost:5001/'
	E que o endpoint é 'Usuario/ValidarSenha'
	E o método http é 'GET'
	E a senha seja '<Senha>'
	Quando validar a senha
	Então a resposta será '<Valido>'

	Exemplos:
		| Senha			| Valido |	
		| ""			| não	 |
		| aa			| não    |
		| ab			| não	 |
		| AAAbbbCc		| não    |
		| AbTp9!foo		| não    |
		| AbTp9!foA		| não    |
		| AbTp9 fok		| não    |
		| AbTp9!fok		| sim    |