\ david cobac
\ juillet 2024
\
\ https://codegolf.stackexchange.com/questions/274092/calculate-sum-of-self-exponentation

s" exp.fs" INCLUDED

CREATE tab 3 , 4 , 6 , 7 ,

: ^ 1 TUCK DO OVER * LOOP * ;
: s 0 SWAP DUP @ 0 DO DUP I 1+ CELLS + @ DUP ^ ROT + SWAP LOOP DROP ;

tab sse
