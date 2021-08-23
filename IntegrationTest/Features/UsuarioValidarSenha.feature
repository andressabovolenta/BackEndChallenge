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
		| AbCd1!Ef		| não    |
		| ABCD1!EFG		| não	 |
		| abcd1!egf		| não    |
		| AbCd!EfGh		| não    |
		| AbCd 1!EfG	| não    |
		| AbCd1!EfA		| não    |
		| AbCd1!EfG		| sim    |