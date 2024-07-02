\ david cobac
\ juillet 2023

: ->LIST ( n1 n2 ... np p -- adrliste )
    DUP >R                         \ p dans le return stack
    HERE SWAP DUP 1 + CELLS ALLOT  \ allocation de p+1 cellules
    2DUP SWAP !                    \ taille dans la 1ere cellule
    SWAP CELL+ SWAP                \ init de la boucle
    BEGIN
        DUP 0= 0=  WHILE           \ = 0 ?
            DUP 1 + ROLL
            ROT TUCK !
            CELL+ SWAP 1 -
    REPEAT
    DROP
    R> 1 + CELLS -                 \ on renvoie l'adresse de départ
;


: ->TSIL ( np np-1 ... n1 p -- adrliste )
    DUP >R 0 ?DO                   \ on inverse la liste
        I ROLL
    LOOP
    R>
    ->LIST
;

: GET ( adrliste n -- elt )
    cells + @ ;

: PUT ( adrliste n elt -- adrliste ) \ on renvoie l'adresse comme
    SWAP ROT DUP ROT CELLS +         \ en RPL dans lequel la nouvelle liste
    ROT SWAP !                       \ est renvoyée (à vérifier)
;

: POS ( adrliste elt -- n )      \ liste : 1re cellule=dimension
    DEPTH 2 - >R                  \ le processus renvoie la position
    SWAP DUP @ 0                  \ ou rien ... donc si ça ne renvoie
    ?DO                           \ rien on renvoie -1 => utilité du DEPTH
        DUP I 1 + GET
        2 PICK =                  \ attention 2 -> 3e élément <> OVER
        IF
            I 1 +
            ROT ROT LEAVE         \ UNROT - oh le vilain break :o
        THEN
    LOOP
    2DROP
    DEPTH R> = IF -1 THEN
;

: GSLIST ( adrliste -- n )
    DUP 0 SWAP @ 0
    ?DO
        OVER I 1 + GET +
    LOOP
    NIP
;

: PILIST ( adrliste -- n )
    DUP 1 SWAP @ 0
    ?DO
        OVER I 1 + GET *
    LOOP
    NIP
;

: OBJ-> ( adrliste -- n1 n2 n3 ... np )
    DUP @ 0 ?DO
        CELL+ DUP @ SWAP
    LOOP
    DROP
;

: XCH ( adrliste i j -- ) \ échange les contenus en i et j
    ROT >R                 \ adrliste dans le Rstack
    DUP R@ SWAP GET        \ on récupère ej
    ROT DUP R@ SWAP GET    \ on récupère ei
    3 ROLL R>
    ROT ROT SWAP PUT       \ on insère ei
    ROT ROT SWAP PUT       \ on insère ej
;