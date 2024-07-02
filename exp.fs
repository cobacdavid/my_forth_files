\ exponentiation naïve
: **NAIF ( b e -- p )
    1 SWAP 0 ?DO OVER * LOOP NIP ;

\ version récursive naïve
: **RER ( b 1 e -- b n 0 )
    DUP IF
	-ROT 2DUP * NIP
	ROT 1-
	RECURSE
    THEN ;

: **RE ( b e -- n )
    1 SWAP **RER DROP NIP ;

\ exponentiation rapide récursive
: **RAPR ( 1 b e -- n )
    DUP 1 = IF
	DROP *
    ELSE
	DUP 2 MOD IF
	    -ROT TUCK * SWAP ROT
	    1-
	ELSE
	    SWAP DUP * SWAP 2 /
	THEN
	RECURSE
    THEN ;

: ** ( b e -- n)
    ?DUP IF 1 -ROT **RAPR ELSE DROP 1 THEN ;

\ exponentiation modulaire naïve
: **MODNAIF ( b e mod -- p )
    -ROT 1 SWAP 0 ?DO OVER * 2 PICK MOD LOOP NIP NIP ;

\ exponentiation modulaire rapide
: **MOD ( b e mod -- p )
    -ROT 1 -ROT              \ mod 1 b e
    BEGIN
	DUP 0> WHILE   
	    DUP 1 AND IF
		-ROT TUCK *
		3 PICK MOD  \ mod e b p
		SWAP ROT    \ mod p b e
	    THEN
	    2/          
	    SWAP DUP *      \ mod p e b 
	    3 PICK MOD      \ mod p e b
	    SWAP            \ mod p b e
    REPEAT
    2DROP NIP ;
