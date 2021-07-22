README 

Apenas projetos feitos em C#.

Existem 2 formas de projetos relacionados a backup

	Vamos para formas de backup, uma delas e a mais simples que se descreve por qual a organização de pasta os  arquivos terão. A outra forma é a de como será feito o backup, que por sua vez muito tem haver com o outro.
	
História da Ideia

	Mas de inicio, tudo começou quando tive a necessidade de  guardar e deixar simples e organizado e as separações de pasta, apesar de ser perfeccionista chegou um momento que tive a necessidade de tornar a organização um pouco mais simples. 
	
	Perfeccionismo  
	 muitos arquivos	 Bom
	Poucos arquivos 	Ruim
	
	Simples
	Muitos arquivos 	 Ruim
	Poucos arquivos 	Bom
	
	Qual é o meio termo ? 
	Da para automatizar utilizando um padrão, que priorize esses dois aspectos ?
	
	Tempos antes tinha curiosidade de entender um algoritmo uma vez criado por um amigo. Esse código era responsável por entrar todas as pastas dentro de um diretório. 
	
	Esse algoritmo utiliza de um método chamado recursividade. Então peguei um algoritmo similar criado pela Microsoft e apliquei dentro do sistema de backup.
	
	 Onde ele entraria em todas as pastas de um determinado diretório e mapearia todos os arquivos e faria uma comparação com um outro determinado diretório. E vice-versa.
	
	Nesse novo sistema eu resolvi utilizar o conceito do sistema de versionamento de arquivo, esse algoritmo leva em consideração o ultimo arquivo modificado. Então chamei isso de sincronização e utilizei isso como critério para a sincronização entre os arquivos já existentes.
	
	Existe dois tipos de sincronização, as entre em pastas e as entre arquivos.
	
	Sinc. Arquivos
	Critérios:	Comparação do ultimo arquivo modificado.
		Comparação de novos arquivos entre os dois diretórios.
		Critério de Usuário 
	
	Sinc. Diretórios
	Critérios: 	  Critério de usuário 
		  Critério de sequência de busca 
	
	
	A sincronização tecnicamente é um objeto de status que valida se o arquivo ou o diretório esta sincronizado.

	onde uma sincronização seria um objeto onde guardaria apenas os dois diretórios relacionados, que por sua vezes poderia estar ligado a diversos outros backup.
		
	Como eu tinha a necessidade de desenvolver algo novo decidi adicionar isso a dispositivos removíveis. Ou seja, seria um sistema portável, dentro do pendrive. 
	
	
Projeto
	Padrões 
		- Command (adaptação)
		- Facade
		- ViewHelper
		- Strategy
		
	
	UML Arquitetura Modelo

	
	UML Domain
		 
		
		
		Dados do Backup:
			Diretorio atual
			Diretorio destino
			FileInfo
		
		Dados do sincronizeFile
			Diretorio atual
			Diretorio destino
			
		Dados do sincronizeDirector 
			Diretorio atual
			Diretorio destino
			
			
			
			
			
		Quais dados são importantes serem registrados?
![image](https://user-images.githubusercontent.com/20491286/126683833-d9456302-dbb7-4e42-8ad4-bf4c7428345c.png)


- FastBackup

	Funcionamento:	

					Identificar a existência de um disco removivel; (n desenv.)*
					
					identificar arquivos novos ou modificados; (n desenv.)
					
					Armazena o diretório de trabalho (onde os arquivos estão sendo modificados);

					Armazena o dirétorio de destino dos arquivos (Onde irá ser salvo o Backup);

					Lista os arquivos encontrados (Novos ou Modificados)

					Efetua o Backup;


	Objetivo: 
					Criar um recurso de Backup Automático de arquivos.

					Reconhecimento automatico dos arquivos seguindo minhas regras de funcionamento. ( n. conquistado)

					Facilidade na modificação das regras. ( n. Conquistado)

					E funcionamento exclusivo por status de funcionamento. (n. Conquistado)



	Usabilidade/ Tarefa:
						 Atualmente tive uma grande dificuldade em fazer backup dos meus arquivos criados e trabalhodos dentro de um dispositivo portátil (pendrive), onde o cenário em que fui imposto não me permitiu o tempo necessário para conseguir armazenar adequadamente meus arquivos pessoais contido no dispositivo portátil. É comum que todo trabalho executado em um computador tenho seu destino adequado dentro de uma pasta específica localizada dentro de uma raíz de pastas. A maior vantagem seria para usuarios com facilidade no prompt de comando no caso o termianl (DOS, Bash ...). Embora a primeira versão não tenho sido feita em terminal, a intenção processiguir com o projeto baseando essas atividades ja feitas, com o desenvolvimento voltado para console.	


	Atividades:     Usuario
						Identificar diretório Inicial e Diret. de Destino 
								Identificação do caminho da raiz a ser monitorada e replicada
								Identificação do caminho de destino onde será feito o backup dos arquivos/ diretórios.
						Requisitar Monitoramento
						Requisitar Lista de arquivos em estado de Modificação
						Executar Backup

					Sistema
						Identificar existência dos diretórios específicados
						Identificar arquivos em trabalho
								Arquivos recem modificados
								Arquivos recem criados	





	Regras de Negócio:	Os diretorios especificados devem existir
						O arquivo deve estar em estado de modificação
						O para prosseguir com o backup deve conter algum arquivo modificado



	Descrição do Problema: 
							Problema(s) Em modificações rápidas 
										Em modificações para repositórios privados

							Afetado(s)  Usuarios envolvidos com o arquivo

							Solução		Integrar os arquivos a um sistema que automatiza 
										o processo de backup dos arquivos recem trabalhados.


	Resumo do(s) usuario(s)

			ex: Perfil: Cliente
				Descrição:	Cliente do estabelecimento
				Responsabilidade: Realizar pedido


		Perfil:
		Descrição:
		Responsabilidade:

	
	Requisitos
				Funcionais:
				Não Funcionais:
								Usabilidade:
								Confiabilidade:
								Desempenho:
								Manutenibilidade:

