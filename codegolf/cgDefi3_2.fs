\ david cobac
\ juillet 2024
\ 
\ https://codegolf.stackexchange.com/questions/273387/cellular-automata-rule-30

\ règle 30 :  000 0 001 1 010 1 011 1 100 1 101 0 110 0 111 0 -> 00011110

: regle ( uregle u3bits -- f ) RSHIFT 1 AND ;  

: xtr3bits ( u64bits i -- u3bits )
    ( extraction du ieme à partir du bit de poids fort )
    64 3 - SWAP - RSHIFT 7 AND ;

: suivant ( uregle u64bits -- u64bits )
    0 62 0 DO           ( uregle u64bits 0 )
	OVER I          ( uregle u64bits 0 u64bits I )
	xtr3bits        ( uregle u64bits 0 u3bits )
	3 PICK SWAP     ( uregle u64bits 0 uregle u3bits )
	regle           ( uregle u64bits 0 nvchiffre )
	62 I - LSHIFT + ( uregle u64bits u64bits2 )
    LOOP NIP NIP ;

: u2str2 ( u -- u )
    ( affichage binaire sur 64 bits )
    CR
    64 0 DO
	DUP 63 I - RSHIFT 1 AND
	0= IF BL ELSE 42 THEN EMIT
    LOOP ;

: triangle ( uregle u1 u2 -- schema )
    2 BASE !
    0 DO u2str2	OVER SWAP suivant LOOP
    DECIMAL ;

\ exemple :
\ 30 2147483648 31 triangle
