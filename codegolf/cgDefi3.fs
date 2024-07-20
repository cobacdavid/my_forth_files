\ david cobac
\ juillet 2024
\ 
\ https://codegolf.stackexchange.com/questions/273387/cellular-automata-rule-30

( 000 0 001 1 010 1 011 1 100 1 101 0 110 0 111 0 )

: regle30 ( u3bits -- f ) DUP 0<> SWAP 5 < AND NEGATE ;

: xtr3bits ( u64bits i -- u3bits )
    ( extraction du ieme à partir du bit de poids fort )
    64 3 - SWAP - RSHIFT 7 AND ;

: suivant ( u64bits -- u64bits )
    0 62 0 DO
	OVER I xtr3bits
	regle30 ( nouveau chiffre )
	62 I - LSHIFT +
    LOOP ;

: u2str ( u -- str ) CR 64 U.R ;

: u2str2 ( u -- str )
    CR
    64 0 DO
	DUP 63 I - RSHIFT 1 AND
	0= IF BL ELSE 42 THEN EMIT
    LOOP ;

: triangle ( u1 u2 -- schema )
    2 BASE !
    0 DO
	DUP u2str2
	suivant
    LOOP
    DECIMAL ;
