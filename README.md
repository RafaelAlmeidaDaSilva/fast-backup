README 

Apenas projetos feitos em C#.

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

