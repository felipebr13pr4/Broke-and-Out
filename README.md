# Broke and Out

This repo is for learning. Comments are welcome. I will not be accepting pullings or modifications as that is not the purpose of this repo.

This will probably just be a Breakout clone but with some more things.

Develop branch will be where recent changes will be. And most of development.

If you clone this project, be aware that your editor game window resolution must correlate to the available resolutions so fonts won't break.
(1080x1920 (Most Ideal), 900x1600, 720x1280, 540x960, 360x640, 180x320)

Project created at "2026-07-26T14:40:21Z", according to this repo's data from https://api.github.com/repos/felipebr13pr4/Broke-and-Out

Link itch: I'll create and add it here later.

# How to play

A to move left
D to move right
Esc to pause
R for quick retry

Hit the ball to make it go up to hit the bricks; damaging them.
Kill all bricks to win the level.
If the ball falls it'll reappear above you, but if there are bricks in the way it will reappear from the top of the screen.

If your HP reaches 0 you die and lose the level.
Good luck! The rest is yours to discover.

(For an better experience, try challenging yourself by taking the least damage and killing the most bricks.)

# Development Notes

Third time using git and github, this time i don't think i had problems with it.

This time the project took a little longer. It was created at "2026-07-26T14:40:21Z", 07/26.
Today's 08/16, so its been 21 days in total (3 weeks) but of course not all days i worked fully, so i'd say its closer to 18 days and of course i didn't work 24 hours a day.
Total project time: 21 days.
Theoretical project time: 18 days.
Actual work time: 5-10 days (only counting when i was actively working on the project).

Re-appearances from last project
- A bit trouble with unity call order.
- Scope creep (Some seemingly small additions can end up needing lots of other additions, snowballing into a big scope increase).
- Lots of iterations of certain things before its decent.
- Reusing things from past projects.


I learned
- A little more on prefabs, inheritance, structs, singletons, const, readonly, static, lists.
- How to use JSon and about it.
- More about how you can re-use things you've done already (i was remaking the UI from scratch before discovering you can import assets, caused some bugs when i imported and i already had a UI lol).
- On lots of things i'll not get them right in the first try and that its okay to do lots of redesigns.
- How to know which edge something touched using contact points (ContactPoint2d.normal).
- How to extract letters from a certain text format.
- Turning text into data.
- Level design isn't easy and might take lots of iterations for a level to be good/decent.
- Unity's stuck to C# version 9 but can be changed to higher versions.
- You can't initialize in structs in C# version 9, but you can create methods that set the values to a default or do things.
- Virtual and Override vs New.
- Abusing your own system to see it's limits to potentially discover new mechanics/quirks.


Next time i should
- Document this section as i go, its easier than having to remember everything i did.
- Step up git etiquette just like i did in this repo (Maybe trying to do branches for features? And maybe better naming).
- Search more and not hesitate to ask things to AI.
- Use AI as a learning tool more (it can be really useful for learning basic things which then you can fuse and build more complex things).
- Debate and think more about the true weight of an addition, even if it seems small.


Did I actually do it? (Did i do past "Next times i should")
---Flappy Cube---
- Step back and reevaluate things. - Yes i did.
- Do more decoupling. - Yes i did.
- Use less public stuff. - Yes i did.
- Do better coding. - Yes i did (debatable).
- Do less over-engineering. - Yes i did.
- Search even more. - Debatable.
---Flappy Cube---

---Pongy Pong---
- Search more. - Debatable.
- Think more (To stop and reconsider things more, when implementing systems thinking if its even necessary, thinking of ways to do a system or thing. Considering sometimes the simpler approach is better). - Yes i did.
- Try doing better naming conventions git-wise (Like branches, commits, etc.). - Yes i did (still working on it though).
- Perhaps use Claude to check for small mistakes and learn from them to not commit them again. - Yes i did (helps alot).
---Pongy Pong---


General Thoughts
- Man, compared to Pongy Pong this feels like a step up in complexity, with the whole brick types, level creator, level system, etc.
- I must say though, once again i have been victim to scope as i thought some things wouldn't take as long as they did, its interesting though that sometimes maaany iterations of a system is needed before its decent or good.
- One cool thing is that if i wanted to increase the scope its quite easy, as in i wouldn't need to rebuild the whole system if i wanted for example a fourth brick type, 10 more levels, way more sounds, more achievements, etc.
- On the AI usage, the points from my last notes on Pongy Pong still stand up. It was quite useful and it's especially good at repetitive work like turning lots of vars into properties; when making data controller and saving controller AI was useful to transform the private vars into properties and the bunch of SetInts. And it seems AI can be really good for learning things which then you can go on and do your own things, just like youtube coding tutorials, written tutorials, etc. Check the script Assets/Scripts/TestingThingsOut for details on that.
- Level design is kinda fun, i tried in general when making levels to make them fun and unique and not just walls of bricks that increase hp like damage sponges and in doing that i really pushed my system lol, some fun things that didn't get into the final build were if you increase brick hp enough they turn invisible for some reason. If you put the speed high enough (like 0.001) they can get REALLY fast and just zoom past you. If you put the firerate value fast enough (like 0.5) it creates a beam since i've set the max amount of bullets to 9 and if the ranged brick is as fast as the bullets its like he has a spear lol.
- The final level i really tried making hard, of course not "takes 30 tries" hard but "takes 5 tries" hard, which was around how many i needed (5-10). I could've made it way harder if the incoming bricks had 5 hp and way easier if 3 to below, 4 seemed to be the sweet spot where you still had to be quite good in your movement and ball precision but not extremely so.
- Some of the levels i've also accidentally (but mostly on purpose) made training for future levels which i think is really good. In general i thought i didn't do good in the levels but after some thought i think i did decently but definitely could be better and i could add more.

# Project Plan

Made at the very start of the repo.

Time to make Breakout.

Breakout core consists of
- A paddle that moves side-to-side.
- A ball that bounces off the paddle and screen boundaries.
- Bricks that when touched by the ball vanish.
- Things don't go outside the screen boundaries.
- Punishment for letting the ball fall down past the paddle.

Things for a polished experience
- 9:16 screen.
- Scoring system.
- All UI essentials, pause button, menu, configs window, main menu.
- Make it so where the ball hit the paddle changes it's bounce trajectory.

Ideas for fun?
- Bricks advance like enemies?
- Bricks shoot like in Space Invaders?
- Combo system? Maybe it makes the paddle and ball faster?
- Power ups?
- Maybe make the paddle able to move up and down?
- Punishment for ball loss is score loss?
- A lives system? Where maybe the punishment for ball loss is live loss?
- Different levels?

# PT BR

# Broke and Out

Este Repo é pra aprendizado. Comentários são bem-vindos. Eu não estarei aceitando pulls ou modificações já que n é o propósito deste repo.

Isto vai provavelmente ser um clone de Breakout com umas coisas a mais.

Se você clonar este projeto, saiba que a sua resolução de janela de jogo tem que ser a mesma das disponíveis no jogo para que as fontes não quebrem.
(1080x1920 (Mais Ideal), 900x1600, 720x1280, 540x960, 360x640, 180x320)

Projeto criado em "2026-07-26T14:40:21Z", de acordo com os dados do repo de https://api.github.com/repos/felipebr13pr4/Broke-and-Out

Link do itch: (Irei botar aqui quando eu cria-lo)

# Como jogar

A para mover para a esquerda
D para mover para a direita
ESC para pausar
R para tentar novamente rápido

Bata na bola para fazer ela ir para cima e bater nos tijolos; dando dano neles.
Mate todos tijolos para vencer o nível.
Se a sua bola cair, ela vai re-aparecer acima de ti, mas se tem tijolos no caminho ela irá re-aparecer do topo da tela.

Se a sua vida chegar a 0 você morre e perde o nível.
Boa sorte! O resto é seu para descobrir.

(Para uma melhor experiência, tente se desafiar tomando o mínimo de dano e matando a maior quantia de tijolos.)

# Notas de desenvolvimento.

Terceira vez usando git e github, desta vez eu acho que não tive problemas.

Desta vez o projeto tomou um pouco mais longo. Ele foi criado em "2026-07-26T14:40:21Z", 26/07.
Hoje é 16/08, então faz 21 dias em total (3 semanas) mas claro que não todos dias eu completamente trabalhei, então eu diria q é mais perto de 18 dias e claro eu n trabalhei 24 horas por dia.
Tempo de projeto: 21 dias.
Tempo teórico de projeto: por volta de 18 dias.
Real tempo de trabalho: 5-10 dias (apenas contando quando eu estava ativamente trabalhando no projeto).

Re-aparências do último projeto
- Um pouco de problemas com a ordem de chamada do unity.
- Aumento de escopo não preciso (Algumas pequenas adições que pareciam pequenas podem acabar precisando de outras adições, fazendo um efeito bola de neve que faz um aumento de escopo maior do que o esperado).
- Várias iterações de certas coisas antes delas ficarem decentes.
- Reusando coisas de projetos passados.


Eu aprendi
- Um pouco mais sobre prefabs, herança, structs, singletons, const, ler-apenas, estáticos, listas. (readonly, static, lists)
- Como usar JSon e sobre ele.
- Mais em como você consegue re-usar coisas que você já fez antes (eu estava refazendo a UI do zero antes de descobrir você consegue importar assets, causou ums bugs quando importei e já tinha a minha UI kkkk.)
- Sobre várias coisas não vão funcionar de primeira e que é ok re-fazer várias vezes.
- Como saber que beira algo tocou usando pontos de contato (ContactPoint2d.normal).
- Como extrair letras de um certo formato de texto.
- Transformar um texto em dados.
- Design de níveis n é fácil e pode tomar várias iterações para um nível ficar bom/decente.
- Unity está preso na versão 9 do C# mas pode ser mudado para versões maiores.
- Você não pode inicializar em structs na versão 9 do C#, mas você pode criar métodos que definem os valores para um padrão ou fazer coisas.
- Virtual e Sobrepor vs Novo (Virtual e Override vs New).
- Abusar o seu próprio sistema para ver os limites e potencialmente descobrir novas mecânicas/peculiaridades.


Na próxima vez eu devo
- Documentar essa seção junto do projeto, é mais fácil do que ter que lembrar tudo que fiz.
- Melhorar minha etiqueta de git que nem eu fiz neste repo (Talvez tentar fazer galhos (branches) para funções? E talvez melhor nomes.).
- Pesquisar mais e não hesitar em perguntar coisas para IA.
- Usar IA como uma ferramenta de aprendizado (IA pode ser muito útil para aprender as coisas básicas na qual você pode fundir e construir coisas mais complexas).
- Discutir e pensar mais sobre o verdadeiro peso de uma adição, até se parece pequena.


Eu de fato fiz? (Eu fiz "Na próxima vez eu devo" passados)
---Flappy Cube---
- Dar um passo para trás e reavaliar as coisas. - Sim eu fiz.
- Fazer mais desacoplamento. - Sim eu fiz.
- Usar menos coisas públicas. - Sim eu fiz.
- Fazer um código melhor. - Sim eu fiz (Discutível).
- Fazer menos sobre-engenharia. - Sim eu fiz.
- Pesquisar ainda mais. - Discutível.
---Flappy Cube---

---Pongy Pong---
- Pesquisar mais. - Discutível.
- Pensar mais (Parar e reconsiderar coisas mais, quando implementando sistemas pensar se sequer é necessário, pensar de jeitos para fazer o sistema ou coisa. Considerar que as vezes o jeito mais simples é melhor). - Sim eu fiz.
- Tentar fazer uma convenção de nome melhor na questão git (Tipo branches, commits, etc). - Sim eu fiz (mas ainda trabalhando nisso).
- Talvez usar Claude para checar por pequenos erros e aprender deles para não comete-los novamente. - Sim eu fiz (ajuda bastante).
---Pongy Pong---


Pensamentos Gerais
- Mano, comparado com o Pongy Pong isso parece uma passo a frente de complexidade, com os tipos de tijolo e tudo, criação de nível, sistema de nível, etc.
- Mas eu devo dizer, novamente eu fui vitima de escopo já que eu achei que algumas coisas não tomariam tanto que nem elas tomaram, mas é interessante que as vezes vaaarias iterações de um sistema são necessarias até ficar decente ou bom.
- Uma coisa legal é que se eu quisesse aumentar o escopo é bem fácil, no sentido de que eu não precisaria reconstruir o sistema inteiro se eu quisesse por exemplo um quarto tipo de tijolo, mais 10 níveis, muitos mais soms, mais conquistas, etc.
- Na usagem de IA, os pontos que fiz no Pongy Pong ainda estão firmes. Foi bem útil e é especialmente bom em trabalhos repetitivos tipo tornar um monte de variáveis em propriedades; quando fiz o controlador de dados (Data Controller) e o controlador de salvamento (Saving Controller) IA foi útil pra transformar as variáveis privadas em propriedades e os vários SetInts. E parece que IA pode ser bem útil para aprender coisas que ai você pode ir e fazer suas próprias coisas, que nem tutoriais de programação no youtube, tutoriais escritos, etc. cheque o script Assets/Scripts/TestingThingsOut para mais detalhes nisso.
- Design de níveis é até que divertido, quando fazendo os níveis eu tentei em geral fazer eles divertidos e únicos e não só paredes de tijolos que aumentam hp que nem esponjas de dano e neste processo eu pushei bastante o meu sistema kkkk, algumas coisas divertidas que não acabaram na versão final é que se você aumentar o HP dos tijolos o suficiente eles se tornam invisíveis por alguma razão. Se você botar a velocidade alta o suficiente (tipo 0.001) eles podem ficar MUITO rápidos e só atravessar você. Se você botar o valor de cadeia de tiro rápido o suficiente (tipo 0.5) ele cria um laser por que o máximo de balas que botei é 9 e se o tijolo de longa distância tem a mesma velocidade que as balas isso faz ele parecer que ele tem uma lança kkkk.
- O nível final eu tentei bastantinho fazer ele difícil, claro que não "toma 30 tentativas" de difícil mas "toma 5 tentativas" de difícil, que foi por volta do tanto que precisei (5-10). Eu poderia ter feito bem mais difícil fazendo os tijolos que descem ter 5 de vida e bem mais fácil se tivessem 3 pra baixo, 4 parece ser o tanto que fica bom aonde você ainda tem que ser bom no movimento e precisão da bola mas não extremamente bom.
- Algum dos níveis eu acidentalmente (mas mais de propósito) fiz serem treinos para níveis futuros na qual eu acho q é bom. Em geral eu pensei que eu não tinha feito bem nos níveis mas depois de considerações eu acho que fui decente mas definitivamente poderia ter feito melhor e adicionado mais.

# Planos do Projeto

Feito no início do repo.

Hora de fazer Breakout.

A essência de Breakout consiste de
- Uma raquete que move lado pra lado.
- Uma bola que quica da raquete e limites de tela.
- Tijolos que quando tocado pela bola desaparecem.
- Coisas não vão para fora dos limites de tela.
- Punimento por deixar a bola passar por volta da raquete e cair.

Coisas para uma experiência polida
- Tela 9:16.
- Sistema de pontuação.
- Todos essenciais de UI, botão de pause, menu, janela de configuração, menu principal.
- Fazer com que aonde a bola bate na raquete ela muda a direção em que ela quica.

Ideias por diversão?
- Tijolos avançam que nem inimigos?
- Tijolos atiram que nem Space Invaders?
- Sistema de combo? Talvez ele faz com que a raquete e bola fiquem mais rápidos?
- Poderes?
- Talvez permitir a raquete ir pra cima e baixo?
- Punimento por fazer a bola cair é perda de pontos?
- Um sistema de vidas? Aonde talvez o punimento da bola cair é uma vida perdida?
- Níveis diferentes?