# Introduzione
Il progetto in questione è un gioco platform sviluppato utilizzando Unity e il linguaggio di programmazione C#. Il gioco, intitolato Knight warrior è basato su una serie di meccaniche classiche dei giochi platform.
L'obbiettivo principale del giocatore è guidare il protagonista attraverso una serie di livelli, raccogliendo fragole e affrontando sfide.

# Obbiettivi specifici
Tra gli obbiettivi specifici del progetto figurano:

- Creare una serie di livelli ben progettati e bilanciati, che offrano una progressione graduale della difficoltà.
- Implementare meccaniche di gioco innovative e interessanti, tra cui la raccolta di power-up, la gestione del tempo e l'interazione con nemici e ostacoli.
- Integrare elementi di personalizzazione e opzioni di gioco, consentendo agli utenti di regolare le impostazioni audio, i controlli e altre preferenze in base alle proprie esigenze e preferenze.
- Checkpoint nei Livelli: Implementare checkpoint all'interno dei livelli per consentire al giocatore di riprendere da determinati punti, garantendo una esperienza di gioco più fluida e meno frustrante.
- Classifica dei Punteggi: Creare una classifica dei punteggi degli utenti, che tenga traccia delle prestazioni di ciascun giocatore in base al numero di fragole raccolte durante il gioco.
- Animazioni e Suoni Personalizzati: Arricchire l'esperienza di gioco con animazioni originali e suoni personalizzati per rendere l'interazione con il gioco più coinvolgente e immersiva.

# Impostazioni Generali
- Splash Screen: Una schermata iniziale personalizzata che introduce il gioco all'utente, creando un'impressione d'attesa e anticipazione.
- Icona Gioco: Un'icona rappresentativa per il gioco, che contribuisce a identificarlo e differenziarlo all'interno del dispositivo o della piattaforma di gioco.

# Main Menu 
- Load Game (Checkpoint): Implementazione di checkpoint all'interno dei livelli, disponibili nei livelli di difficoltà facile, normale e difficile, per consentire al giocatore di riprendere da determinati punti.
- Options:
    - Sound/Music: Possibilità di regolare il volume del suono e della musica direttamente dal menu, offrendo un controllo personalizzato 
       sull'esperienza audio del giocatore.
    - Controls: Opzione per modificare i controlli del gioco, con la possibilità di scegliere tra due set di tasti predefiniti (freccette o 
       WASD) durante il gioco.


# Classifica
- Ordinata con Rimpiazzo Dinamico delle Entry: Implementazione di una classifica dei punteggi degli utenti, basata sul numero di fragole 
  raccolte durante il gioco, con aggiornamento dinamico delle voci e cancellazione dei punteggi più bassi.

# Gameplay
- Score: Incremento dello score in base al numero di fragole raccolte durante il gioco, incentivando l'esplorazione e la ricerca di 
  collezionabili.
- PowerUp/Shop/Bonus Giocatore: Presenza di tre power-up disponibili per il giocatore, che aumentano la velocità, il salto e la velocità delle 
  palle da fuoco, offrendo nuove opportunità strategiche durante il gameplay.
- Gioco a Tempo: Implementazione di un limite di tempo per completare i livelli, aggiungendo una componente di sfida e premendo il giocatore a 
  giocare in modo efficiente.
- Presenza di Nemici/Sfida: Introduzione di nemici con comportamenti di base (ad esempio inseguimento del giocatore e attacchi automatici), 
  aumentando la complessità e la sfida del gioco.
- Livelli di Difficoltà: Offerta di tre livelli di difficoltà (facile, normale, difficile) per adattarsi alle preferenze e alle abilità dei 
  giocatori.


  # Implementazioni avanzate
  - Linguaggio di Programmazione C#: Utilizzo del linguaggio di programmazione C# per lo sviluppo del gioco, garantendo una struttura solida e 
    una programmazione orientata agli oggetti.
  - PlayerPrefs: Utilizzo di PlayerPrefs per gestire la classifica e i punteggi degli utenti.
  - Singleton: Implementazione di Singleton per GameManager e SoundManager, garantendo l'accesso univoco a tali componenti all'interno del gioco.
  - Coroutines: Utilizzo di Coroutines per gestire azioni asincrone come trappole e trampolini, migliorando la reattività e l'ottimizzazione del 
    gioco.
  - Ereditarietà e Overriding: Utilizzo di ereditarietà e overriding per creare e gestire comportamenti specializzati per trappole, proiettili 
    nemici e altre entità del gioco.
  - Animazioni e Suoni Personalizzati: Integrazione di animazioni originali e suoni personalizzati per arricchire l'esperienza audiovisiva del 
    gioco.


  # Conclusione
  Il progetto "Knight warrior" rappresenta un esempio di un gioco platform sviluppato con cura e attenzione ai dettagli. Attraverso l'utilizzo del linguaggio di programmazione C# e di Unity.




