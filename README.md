# GAME DESIGN DOCUMENT

![Game Logo](media-readme/game-logo.png "Plane Missiles")

## O PROJETO

Projeto desenvolvido por **Jonathan Veras** e **Yan Hermanny** sob supervisão dos professores **André Cotelli** e **Rogério Pinheiro** como forma de avaliação para a disciplina **Projeto Integrador VI** do curso **Sistemas de Informação** da **Faculdade Cesgranrio**.

Inspirado no jogo mobile [Missiles!](https://play.google.com/store/apps/details?id=pl.macaque.Missiles&hl=pt_BR&gl=US "Google Play Store"), o projeto foi desenvolvido no Unity com scripts na linguagem C#.

Créditos SFX:

- background_music -> 8Bit Music - 062022 - Artist: GWriterStudio
- prop-plane_sf -> Sound Effect from [Pixabay](https://pixabay.com/sound-effects/?utm_source=link-attribution&amp;utm_medium=referral&amp;utm_campaign=music&amp;utm_content=14513)
- destroy_missile_sf -> Sound Effect from [Pixabay](https://pixabay.com/sound-effects/?utm_source=link-attribution&amp;utm_medium=referral&amp;utm_campaign=music&amp;utm_content=85216)
- collect_star_sf -> Sound Effect from [Pixabay](https://pixabay.com/sound-effects/?utm_source=link-attribution&amp;utm_medium=referral&amp;utm_campaign=music&amp;utm_content=6075)

## SUMÁRIO

[1. INTRODUÇÃO](#1-introdução)</br>
[1.1. Resumo da História](#11-resumo-da-história)</br>
[1.2. Gênero e Semelhanças](#12-gênero-e-semelhanças)</br>
[1.3. Gameplay Overview](#13-gameplay-overview)</br>
[2. Personagens](#2-personagens)</br>
[2.1. Aeronave](#21-aeronave)</br>
[2.2. Míssil](#22-míssil)</br>
[2.3. Estrela](#23-estrela)</br>
[3. Mecânica do Jogo](#3-mecânica-do-jogo)</br>
[3.1. Controles](#31-controles)</br>
[3.2. Câmera](#32-câmera)</br>
[3.3. Pontuação](#33-pontuação)</br>
[4. Universo do Jogo](#4-universo-do-jogo)</br>
[5. Interface](#5-interface)</br>
[5.1. Tela de Login](#51-tela-de-login)</br>
[5.2. Tela Inicial](#52-tela-inicial)</br>
[5.3. Tela de Gameplay](#53-tela-de-gameplay)</br>
[5.4. Tela de Pause](#54-tela-de-pause)</br>
[5.5. Tela de Highscores](#55-tela-de-highscores)</br>
[5.6. Tela de Game Over](#56-tela-de-game-over)</br>
[6. Detalhes Técnicos de Implementação](#6-detalhes-técnicos-de-implementação)</br>
[6.1. Hardware](#61-hardware)</br>
[6.2. Software](#62-software)</br>
[6.3. Engine](#63-engine)</br>
[6.4. Assets](#64-assets)</br>
[6.5. Ranking Online](#65-ranking-online)</br>
[6.6. PlayerPrefs](#66-playerprefs)</br>
[6.7. Desafios](#67-desafios)</br>
[7. Cronograma](#7-cronograma)</br>
[8. Conclusão](#8-conclusão)
[9. Referência](#9-referência)</br>

## 1. INTRODUÇÃO

Este documento tem o intuito de demonstrar aspectos técnicos, artísticos e narrativos do jogo "Plane Missiles". Será apresentado o enredo e a mecânica de jogo, seu objetivo, aspectos de jogabilidade e ferramentas de desenvolvimento.

Com estes pontos é possível dar sequência ao processo de produção e desenvolvimento do jogo.

### 1.1. Resumo da História

Um piloto de aeronave deve fugir dos mísseis enviados para destruí-la no vasto céu azul, enquanto faz os mísseis se chocarem e coleta estrelas para ganhar pontos.

### 1.2. Gênero e Semelhanças

É um jogo no estilo arcade de ação em terceira pessoa, onde o objetivo é sobreviver o maior tempo possível, coletando pontos e desviando dos mísseis. Possui inspiração em jogos como Missiles! (Figura 1) e Missile Escape (Figura 2), disponível no Google Play.

![Gameplay Missiles!](media-readme/missiles!.png "Gameplay Missiles!")</br>
*Figura 1: Tela do jogo missiles!*

![Gameplay Missile Escape](media-readme/missile-escape.png "Gameplay Missile Escape")</br>
*Figura 2: Tela do jogo missile escape*

### 1.3. Gameplay Overview

Um piloto a bordo de uma aeronave deve fugir dos mísseis enviados para destruí-lo e sobreviver durante o maior tempo possível.

Através de manobras evasivas, o piloto consegue destruir os mísseis os fazendo atingirem uns aos outros e, além disso, pode coletar estrelas, que aumentam sua pontuação e aparecem aleatoriamente no cenário em intervalos variados.

Existem três tipos de mísseis, cada um com uma velocidade diferente. Porém, todos são mais velozes que a aeronave, portanto é necessário agilidade e raciocínio rápido para evitá-los e sobreviver o maior tempo possível.

## 2. Personagens

### 2.1. Aeronave

Aeronave (Figura 3) guiada pelo jogador que irá coletar estrelas e fugir dos mísseis.

![Plane](media-readme/plane.jpg "Plane")</br>
*Figura 3: Aeronave manipulada pelo jogador*

### 2.2. Míssil

Míssil (Figura 4) teleguiado para destruir a aeronave, sendo três tipos com cores diferentes. Cada tipo possui uma velocidade diferente, todas superiores à do jogador.

![Missiles](media-readme/missiles.png "Missiles")</br>
*Figura 4: Mísseis inimigos*

### 2.3. Estrela

Estrela (Figura 5) colocada aleatoriamente no mapa para ser coletada e adquirir pontos extras.

![Star](media-readme/star.jpeg)</br>
*Figura 5: Estrela de pontuação*

## 3. Mecânica do Jogo

O jogo tem como mecânica básica o voo de uma aeronave se movimentando em apenas duas dimensões enquanto mísseis inimigos a perseguem para destruí-la.

### 3.1. Controles

O usuário poderá controlar a aeronave através do touch screen do celular, utilizando setas direcionais (Figura 6) localizadas do lado esquerdo e direito na parte inferior da tela.

![Left Button](media-readme/left-button.jpeg "Left Button")![Right Button](media-readme/right-button.jpeg "Right Button")</br>
*Figura 6: Setas de controle de movimentação*

### 3.2. Câmera

A câmera de jogo está localizada acima da aeronave, fornecendo uma visão de cima de todo o cenário, portanto o jogador estará em terceira pessoa (Figura 7), com uma visão superior da aeronave, dos mísseis e das estrelas.

![Camera View](media-readme/camera-view.jpeg "Camera View")</br>
*Figura 7: Visão da câmera de jogo*

### 3.3. Pontuação

O objetivo do jogo é acumular o maior número de pontos antes da aeronave ser destruída. Para isso existem três formas de somar pontos:

- A cada segundo sobrevivendo aos ataques dos mísseis, o jogador soma 1 ponto.
- Cada estrela coletada equivale a 10 pontos.
- Cada míssil destruído gera 2,5 pontos extras ao jogador. Dessa forma, à cada choque entre mísseis que o jogador causar, serão somados 5 pontos, visto que dois mísseis serão destruídos

## 4. Universo do Jogo

O universo do jogo se baseia em um infinito céu azul com nuvens brancas, onde mísseis inimigos são lançados para destruir a aeronave do jogador.

## 5. Interface

### 5.1. Tela de Login

Ao iniciar o jogo pela primeira vez, um campo de login é exibido para o usuário fornecer seu nome, que será usado para registro dos seus melhores resultados. Essa tela é exibida apenas na primeira inicialização, uma vez que o nome registrado ficará salvo para utilização nas próximas vezes.

![Login Screen](media-readme/login-screen.png "Login Screen")</br>
*Figura 8: Tela de login*

### 5.2. Tela Inicial

A tela inicial é composta pela logo do jogo centralizada na parte superior, com o botão de play abaixo e a aeronave no centro da tela na posição inicial de jogo.

Mais abaixo, fica o botão de highscores permitindo a consulta do ranking de pontuação online.

No canto superior direito ficam os botões para ligar e desligar os efeitos sonoros e a música de fundo do jogo de forma independente.

![Start Screen](media-readme/start-screen.jpg)</br>
*Figura 9: Imagem da tela inicial*

### 5.3. Tela de Gameplay

A tela do jogo é composta pelos botões de controle da aeronave, informações de tempo de jogo e estrelas coletadas e o botão de pause. Dessa forma, o jogo possui um visual limpo, mas com todas as informações necessárias.

![Gameplay](media-readme/gameplay.jpg "Gameplay")</br>
*Figura 10: Imagem do jogo com HUD*

### 5.4. Tela de Pause

A tela de pause contém os botões e continuar e voltar para tela inicial.

![Pause Screen](media-readme/pause-screen.jpg "Pause Screen")</br>
*Figura 11: Tela de pause*

### 5.5. Tela de Highscores

A tela de pontuação exibe o ranking dos jogadores com as 100 melhores pontuações de forma decrescente. Conforme a quantidade de registros aumenta, a lista se torna rolável para possibilitar a visualização de todos os placares.

No canto superior esquerdo, está localizado o botão para voltar para a tela inicial.

![Highscores](media-readme/highscores.jpg)</br>
*Figura 12: Tela de highscores*

### 5.6. Tela de Game Over

Ao ser destruída pelos mísseis, a aeronave é destruída e é exibida a tela de game over, informando os detalhes da pontuação e com opções de ir para a tela de highscores ou retornar à tela inicial.

![Game Over](media-readme/game-over.jpeg "Game Over")</br>
*Figura 13: Tela de gameover*

## 6. Detalhes Técnicos de Implementação

Neste capítulo serão abordados os aspectos técnicos relacionados ao desenvolvimento do jogo.

### 6.1. Hardware

Foram utilizados computadores com Windows 10, sempre respeitando os requisitos mínimos exigidos para execução da engine utilizada.

### 6.2. Software

Foram utilizadas as seguintes ferramentas para o desenvolvimento:

- Visual Studio Code para criação e edição dos scripts utilizados.
- Paint.net para criar e editar as imagens utilizadas nos elementos gráficos do jogo.

### 6.3. Engine

Foi utilizado a engine Unity3D para o desenvolvimento do projeto do tipo URP (Universal Render Pipeline). O projeto é configurado para dispositivos Android e portanto foi necessária a instalação do módulo Android Build Support e suas bibliotecas.

### 6.4. Assets

O jogo utiliza alguns assets de pacotes disponibilizados por terceiros na Asset Store:

- AwesomeCartoonPlanes foi utilizado para criar a aeronave do jogador.
- Free Aircraft Pack foi utilizada para criar as nuvens presentes no cenário de jogo.
- Fx Explosion Pack forneceu as explosões utilizadas na destruição dos mísseis e do jogador.
- Gems Ultimate Pack possui a estrela utilizada como item de pontuação no jogo.
- Rocket Missiles and Bombs foi utilizado para criar os mísseis inimigos.

Além disso, utilizamos arquivos de áudio para ambientação do jogo. Os efeitos sonoros foram adquiridos livre de licença no site Pixabay e a música de fundo tem origem na Asset Store.

- prop-plane_sfx.mp3 - efeito sonoro representando o motor da aeronave.
- collect_star_sfx.mp3 - efeito sonoro que indica a coleta de uma estrela.
- destroy_missile_sfx.wav - efeito sonoro da explosão dos mísseis.
- missile_launch_sfx.mp3 - efeito sonoro indicando o lançamento de um míssil.
- plane_explosion_sfx.wav - efeito sonoro da explosão da aeronave.
- background_music.wav - música de fundo do jogo.

### 6.5. Ranking Online

Uma característica muito importante do jogo é o ranking online. Com ele os usuários podem registrar suas pontuações e acompanhar a classificação dentre todos os jogadores.

Para implementarmos essa funcionalidade, utilizamos a plataforma da LootLocker, que, em sua versão grátis, fornece todas as funções que o jogo necessita.

### 6.6. PlayerPrefs

Para algumas funcionalidades, é importante que informações fornecidas pelo usuário possam ser persistidas para as próximas sessões. Para isso, foi utilizado o PlayerPrefs, ferramenta do Unity que permite salvar dados no armazenamento do dispositivo e acessar esses dados quando necessário.

Essa ferramenta foi utilizada para salvar o nome do usuário, que é usado para registro da pontuação no LootLocker. Esse nome, fornecido na tela de login, é a identificação do jogador no sistema para associar suas pontuações. Com o PlayerPrefs, o usuário precisa informar seu nome apenas na primeira sessão, melhorando a experiência e prevenindo possíveis erros que aconteceriam caso fosse preciso digitar o nome sempre que um placar fosse registrado.

Além disso, o PlayerPrefs também foi utilizado para persistir as configurações de som escolhidas pelo usuário. Sempre que o áudio da música de fundo ou dos efeitos sonoros forem ativados ou desativados, essa informação é salva e persiste para a próxima sessão. Assim, se o usuário preferir uma experiência de jogo sem a música de fundo por exemplo, ao desativá-la em uma sessão, todas as próximas vão ser iniciadas com essa configuração já desativada.

### 6.7. Desafios

O processo de desenvolvimento desse projeto gerou diversos desafios e, consequentemente, aprendizados. Dentre eles, destaca- se a implementação da movimentação dos mísseis inimigos. Tornar essa movimentação natural e, ao mesmo tempo, ajustar a velocidade e a capacidade de mudança de direção para definir o nível de dificuldade do jogo foi bastante complexo. Cada míssil tem uma velocidade e uma curvatura diferente em sua movimentação, o que faz com que a estratégia de movimentação do jogador precise ser diferente para escapar de cada tipo de míssil inimigo.

Outro desafio foi desenvolver o timer do jogo. Muitos processos do projeto são dependentes do tempo de jogo. Um míssil, por exemplo, tem um tempo de vida definido em 20 segundos. Da mesma forma, os mísseis são instanciados em intervalos aleatórios delimitados entre 6 e 10 segundos. O mesmo ocorre na instanciação das estrelas, mas com intervalo delimitado entre 40 e 60 segundos.

Por isso, foi criado o timer, que seria utilizado em todas essas verificações. Para isso, foi preciso utilizar Coroutines, um mecanismo muito útil para a execução de tarefas em paralelo.

## 7. Cronograma

![Cronograma](media-readme/cronograma.png)</br>
*Figura 14: Cronograma do projeto*

## 8. Conclusão

Conclui-se que esse projeto colocou em prática todo o aprendizado de jogos I e jogos II adquirido em sala de aula, desafiando os alunos a criarem um jogo onde foi necessário colocar seu conhecimento à prova.

Foi atingido o objetivo de criar um jogo mobile com os requisitos de conter um placar online e ser pertinente e funcional.

Concluindo, a disciplina de Projeto Integrador VI conseguiu oferecer uma experiência extraordinária para os alunos de Sistemas da Informação, alinhando prática e teoria.

## 9. Referência

LootLocker - <https://lootlocker.com/></br>
Pixabay - <https://pixabay.com/sound-effects/></br>
Missiles! - <https://play.google.com/store/apps/details?id=pl.macaque.Missiles&hl=pt_BR&gl=US&pli=1></br>
Missile Escape - <https://play.google.com/store/apps/details?id=com.kolibri.MissileEscape&hl=pt_BR&gl=US>
