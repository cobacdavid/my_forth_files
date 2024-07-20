\ david cobac
\ juillet 2024
\
\ https://codegolf.stackexchange.com/questions/273875/segments-of-a-string-doubling-in-length


: mytype ( a u -- )
    1 BEGIN OVER 0> WHILE
	    SWAP -ROT 2DUP TYPE BL EMIT
	    TUCK CHARS + -ROT
	    TUCK - SWAP DUP +
    REPEAT ;


s" abcdefghijklmno" mytype