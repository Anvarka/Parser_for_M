grammar Example;

// stmt: var = expr; expr → a + b... 
// FILE
// a = 1 + 1;
// b = (1 + 1) + a;

// P
programm
    :
    '{' REL_NAME '=' LAMBDA var_list '.' target ';' '}' target
    ;
    
LAMBDA
    :
    '\\'
    ;
    
VAR
    :
    [a-zA-Z][a-zA-Z0-9]*
    ;
        
var_list
    :
    | VAR
    | VAR ',' var_list
    ;

// G 
target
    :
    term UNIFY term
    | target '/\\' target
    | target '\\/' target
    | 'fresh{' var_list '}'
    | REL_NAME '()'
    | REL_NAME '(' t_seq ')'
    ;
    
REL_NAME
    :
    '_REL_'VAR
    ;
    
    
UNIFY
    :
    '=='
    ;
// T
term
    :
    | var_list
    | CONS_NAME '()'
    | CONS_NAME '(' t_seq ')'
    ;
    
// t1, t2, t3, ..., tn
t_seq
    :
    | term
    | term ',' t_seq
    ;
     
CONS_NAME
    :
    '_CONS_'VAR
    ;

//programm
//    :
//    (stmt ';')+
//    ;
//
//stmt
//    :
//    VAR '=' expr
//    ;
//
//expr
//    :
//    | NUMBER
//    | VAR
//    | expr '+' expr
//    | expr '-' expr
//    | expr '*' expr
//    | expr '/' expr
//    ;
//

//NUMBER
//    :
//    ('1' .. '9') ('0' .. '9')*
//    ;
//
WS : [\n\t ] -> skip;