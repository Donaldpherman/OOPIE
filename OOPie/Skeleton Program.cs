using System;
using System.IO;
using System.Runtime.Serialization;
using com.calitha.goldparser.lalr;
using com.calitha.commons;
using com.calitha.goldparser;

namespace OOPieCore
{

    [Serializable()]
    public class SymbolException : System.Exception
    {
        public SymbolException(string message) : base(message)
        {
        }

        public SymbolException(string message,
            Exception inner) : base(message, inner)
        {
        }

        protected SymbolException(SerializationInfo info,
            StreamingContext context) : base(info, context)
        {
        }

    }

    [Serializable()]
    public class RuleException : System.Exception
    {

        public RuleException(string message) : base(message)
        {
        }

        public RuleException(string message,
                             Exception inner) : base(message, inner)
        {
        }

        protected RuleException(SerializationInfo info,
                                StreamingContext context) : base(info, context)
        {
        }

    }

    enum SymbolConstants : int
    {
        SYMBOL_EOF                        =   0, // (EOF)
        SYMBOL_ERROR                      =   1, // (Error)
        SYMBOL_WHITESPACE                 =   2, // (Whitespace)
        SYMBOL_COMMENTEND                 =   3, // (Comment End)
        SYMBOL_COMMENTLINE                =   4, // (Comment Line)
        SYMBOL_COMMENTSTART               =   5, // (Comment Start)
        SYMBOL_MINUS                      =   6, // '-'
        SYMBOL_MINUSMINUS                 =   7, // --
        SYMBOL_EXCLAM                     =   8, // '!'
        SYMBOL_EXCLAMEQ                   =   9, // '!='
        SYMBOL_PERCENT                    =  10, // '%'
        SYMBOL_PERCENTEQ                  =  11, // '%='
        SYMBOL_AMP                        =  12, // '&'
        SYMBOL_AMPAMP                     =  13, // '&&'
        SYMBOL_AMPEQ                      =  14, // '&='
        SYMBOL_LPARAN                     =  15, // '('
        SYMBOL_RPARAN                     =  16, // ')'
        SYMBOL_TIMES                      =  17, // '*'
        SYMBOL_TIMESEQ                    =  18, // '*='
        SYMBOL_COMMA                      =  19, // ','
        SYMBOL_DIV                        =  20, // '/'
        SYMBOL_DIVEQ                      =  21, // '/='
        SYMBOL_COLON                      =  22, // ':'
        SYMBOL_SEMI                       =  23, // ';'
        SYMBOL_QUESTION                   =  24, // '?'
        SYMBOL_LBRACKET                   =  25, // '['
        SYMBOL_RBRACKET                   =  26, // ']'
        SYMBOL_CARET                      =  27, // '^'
        SYMBOL_CARETEQ                    =  28, // '^='
        SYMBOL_LBRACE                     =  29, // '{'
        SYMBOL_PIPE                       =  30, // '|'
        SYMBOL_PIPEPIPE                   =  31, // '||'
        SYMBOL_PIPEEQ                     =  32, // '|='
        SYMBOL_RBRACE                     =  33, // '}'
        SYMBOL_TILDE                      =  34, // '~'
        SYMBOL_PLUS                       =  35, // '+'
        SYMBOL_PLUSPLUS                   =  36, // '++'
        SYMBOL_PLUSEQ                     =  37, // '+='
        SYMBOL_LT                         =  38, // '<'
        SYMBOL_LTLT                       =  39, // '<<'
        SYMBOL_LTLTEQ                     =  40, // '<<='
        SYMBOL_LTEQ                       =  41, // '<='
        SYMBOL_EQ                         =  42, // '='
        SYMBOL_MINUSEQ                    =  43, // '-='
        SYMBOL_EQEQ                       =  44, // '=='
        SYMBOL_GT                         =  45, // '>'
        SYMBOL_MINUSGT                    =  46, // '->'
        SYMBOL_GTEQ                       =  47, // '>='
        SYMBOL_GTGT                       =  48, // '>>'
        SYMBOL_GTGTEQ                     =  49, // '>>='
        SYMBOL_ABSTRACT                   =  50, // abstract
        SYMBOL_ADD                        =  51, // add
        SYMBOL_AS                         =  52, // as
        SYMBOL_ASSEMBLY                   =  53, // assembly
        SYMBOL_BASE                       =  54, // base
        SYMBOL_BOOL                       =  55, // bool
        SYMBOL_BREAK                      =  56, // break
        SYMBOL_BYTE                       =  57, // byte
        SYMBOL_CASE                       =  58, // case
        SYMBOL_CATCH                      =  59, // catch
        SYMBOL_CHAR                       =  60, // char
        SYMBOL_CHARLITERAL                =  61, // CharLiteral
        SYMBOL_CHECKED                    =  62, // checked
        SYMBOL_CLASS                      =  63, // class
        SYMBOL_CONST                      =  64, // const
        SYMBOL_CONTINUE                   =  65, // continue
        SYMBOL_DECIMAL                    =  66, // decimal
        SYMBOL_DECLITERAL                 =  67, // DecLiteral
        SYMBOL_DEFAULT                    =  68, // default
        SYMBOL_DELEGATE                   =  69, // delegate
        SYMBOL_DO                         =  70, // do
        SYMBOL_DOUBLE                     =  71, // double
        SYMBOL_ELSE                       =  72, // else
        SYMBOL_ENUM                       =  73, // enum
        SYMBOL_EVENT                      =  74, // event
        SYMBOL_EXPLICIT                   =  75, // explicit
        SYMBOL_EXTERN                     =  76, // extern
        SYMBOL_FALSE                      =  77, // false
        SYMBOL_FIELD                      =  78, // field
        SYMBOL_FINALLY                    =  79, // finally
        SYMBOL_FIXED                      =  80, // fixed
        SYMBOL_FLOAT                      =  81, // float
        SYMBOL_FOR                        =  82, // for
        SYMBOL_FOREACH                    =  83, // foreach
        SYMBOL_GET                        =  84, // get
        SYMBOL_GOTO                       =  85, // goto
        SYMBOL_HEXLITERAL                 =  86, // HexLiteral
        SYMBOL_IDENTIFIER                 =  87, // Identifier
        SYMBOL_IF                         =  88, // if
        SYMBOL_IMPLICIT                   =  89, // implicit
        SYMBOL_IN                         =  90, // in
        SYMBOL_INT                        =  91, // int
        SYMBOL_INTERFACE                  =  92, // interface
        SYMBOL_INTERNAL                   =  93, // internal
        SYMBOL_IS                         =  94, // is
        SYMBOL_LOCK                       =  95, // lock
        SYMBOL_LONG                       =  96, // long
        SYMBOL_MEMBERNAME                 =  97, // MemberName
        SYMBOL_METHOD                     =  98, // method
        SYMBOL_MODULE                     =  99, // module
        SYMBOL_NAMESPACE                  = 100, // namespace
        SYMBOL_NEW                        = 101, // new
        SYMBOL_NULL                       = 102, // null
        SYMBOL_OBJECT                     = 103, // object
        SYMBOL_OPERATOR                   = 104, // operator
        SYMBOL_OUT                        = 105, // out
        SYMBOL_OVERRIDE                   = 106, // override
        SYMBOL_PARAM                      = 107, // param
        SYMBOL_PARAMS                     = 108, // params
        SYMBOL_PARTIAL                    = 109, // partial
        SYMBOL_PRIVATE                    = 110, // private
        SYMBOL_PROPERTY                   = 111, // property
        SYMBOL_PROTECTED                  = 112, // protected
        SYMBOL_PUBLIC                     = 113, // public
        SYMBOL_READONLY                   = 114, // readonly
        SYMBOL_REALLITERAL                = 115, // RealLiteral
        SYMBOL_REF                        = 116, // ref
        SYMBOL_REMOVE                     = 117, // remove
        SYMBOL_RETURN                     = 118, // return
        SYMBOL_SBYTE                      = 119, // sbyte
        SYMBOL_SEALED                     = 120, // sealed
        SYMBOL_SET                        = 121, // set
        SYMBOL_SHORT                      = 122, // short
        SYMBOL_SIZEOF                     = 123, // sizeof
        SYMBOL_STACKALLOC                 = 124, // stackalloc
        SYMBOL_STATIC                     = 125, // static
        SYMBOL_STRING                     = 126, // string
        SYMBOL_STRINGLITERAL              = 127, // StringLiteral
        SYMBOL_STRUCT                     = 128, // struct
        SYMBOL_SWITCH                     = 129, // switch
        SYMBOL_THIS                       = 130, // this
        SYMBOL_THROW                      = 131, // throw
        SYMBOL_TRUE                       = 132, // true
        SYMBOL_TRY                        = 133, // try
        SYMBOL_TYPE                       = 134, // type
        SYMBOL_TYPEOF                     = 135, // typeof
        SYMBOL_UINT                       = 136, // uint
        SYMBOL_ULONG                      = 137, // ulong
        SYMBOL_UNCHECKED                  = 138, // unchecked
        SYMBOL_UNSAFE                     = 139, // unsafe
        SYMBOL_USHORT                     = 140, // ushort
        SYMBOL_USING                      = 141, // using
        SYMBOL_VIRTUAL                    = 142, // virtual
        SYMBOL_VOID                       = 143, // void
        SYMBOL_VOLATILE                   = 144, // volatile
        SYMBOL_WHILE                      = 145, // while
        SYMBOL_ACCESSOPT                  = 146, // <Access Opt>
        SYMBOL_ACCESSORDEC                = 147, // <Accessor Dec>
        SYMBOL_ADDEXP                     = 148, // <Add Exp>
        SYMBOL_ANDEXP                     = 149, // <And Exp>
        SYMBOL_ARGLIST                    = 150, // <Arg List>
        SYMBOL_ARGLISTOPT                 = 151, // <Arg List Opt>
        SYMBOL_ARGUMENT                   = 152, // <Argument>
        SYMBOL_ARRAYINITIALIZER           = 153, // <Array Initializer>
        SYMBOL_ARRAYINITIALIZEROPT        = 154, // <Array Initializer Opt>
        SYMBOL_ASSIGNTAIL                 = 155, // <Assign Tail>
        SYMBOL_ATTRIBLIST                 = 156, // <Attrib List>
        SYMBOL_ATTRIBOPT                  = 157, // <Attrib Opt>
        SYMBOL_ATTRIBSECTION              = 158, // <Attrib Section>
        SYMBOL_ATTRIBTARGETSPECOPT        = 159, // <Attrib Target Spec Opt>
        SYMBOL_ATTRIBUTE                  = 160, // <Attribute>
        SYMBOL_BASETYPE                   = 161, // <Base Type>
        SYMBOL_BLOCK                      = 162, // <Block>
        SYMBOL_BLOCKORSEMI                = 163, // <Block or Semi>
        SYMBOL_CATCHCLAUSE                = 164, // <Catch Clause>
        SYMBOL_CATCHCLAUSES               = 165, // <Catch Clauses>
        SYMBOL_CLASSBASELIST              = 166, // <Class Base List>
        SYMBOL_CLASSBASEOPT               = 167, // <Class Base Opt>
        SYMBOL_CLASSDECL                  = 168, // <Class Decl>
        SYMBOL_CLASSITEM                  = 169, // <Class Item>
        SYMBOL_CLASSITEMDECSOPT           = 170, // <Class Item Decs Opt>
        SYMBOL_COMPAREEXP                 = 171, // <Compare Exp>
        SYMBOL_COMPILATIONITEM            = 172, // <Compilation Item>
        SYMBOL_COMPILATIONITEMS           = 173, // <Compilation Items>
        SYMBOL_COMPILATIONUNIT            = 174, // <Compilation Unit>
        SYMBOL_CONDITIONALEXP             = 175, // <Conditional Exp>
        SYMBOL_CONSTANTDEC                = 176, // <Constant Dec>
        SYMBOL_CONSTANTDECLARATOR         = 177, // <Constant Declarator>
        SYMBOL_CONSTANTDECLARATORS        = 178, // <Constant Declarators>
        SYMBOL_CONSTRUCTORDEC             = 179, // <Constructor Dec>
        SYMBOL_CONSTRUCTORDECLARATOR      = 180, // <Constructor Declarator>
        SYMBOL_CONSTRUCTORINIT            = 181, // <Constructor Init>
        SYMBOL_CONSTRUCTORINITOPT         = 182, // <Constructor Init Opt>
        SYMBOL_CONVERSIONOPERATORDECL     = 183, // <Conversion Operator Decl>
        SYMBOL_DELEGATEDECL               = 184, // <Delegate Decl>
        SYMBOL_DESTRUCTORDEC              = 185, // <Destructor Dec>
        SYMBOL_DIMSEPARATORS              = 186, // <Dim Separators>
        SYMBOL_ENUMBASEOPT                = 187, // <Enum Base Opt>
        SYMBOL_ENUMBODY                   = 188, // <Enum Body>
        SYMBOL_ENUMDECL                   = 189, // <Enum Decl>
        SYMBOL_ENUMITEMDEC                = 190, // <Enum Item Dec>
        SYMBOL_ENUMITEMDECS               = 191, // <Enum Item Decs>
        SYMBOL_ENUMITEMDECSOPT            = 192, // <Enum Item Decs Opt>
        SYMBOL_EQUALITYEXP                = 193, // <Equality Exp>
        SYMBOL_EVENTACCESSORDECS          = 194, // <Event Accessor Decs>
        SYMBOL_EVENTDEC                   = 195, // <Event Dec>
        SYMBOL_EXPRESSION                 = 196, // <Expression>
        SYMBOL_EXPRESSIONLIST             = 197, // <Expression List>
        SYMBOL_EXPRESSIONOPT              = 198, // <Expression Opt>
        SYMBOL_FIELDDEC                   = 199, // <Field Dec>
        SYMBOL_FINALLYCLAUSEOPT           = 200, // <Finally Clause Opt>
        SYMBOL_FIXEDPTRDEC                = 201, // <Fixed Ptr Dec>
        SYMBOL_FIXEDPTRDECS               = 202, // <Fixed Ptr Decs>
        SYMBOL_FORCONDITIONOPT            = 203, // <For Condition Opt>
        SYMBOL_FORINITOPT                 = 204, // <For Init Opt>
        SYMBOL_FORITERATOROPT             = 205, // <For Iterator Opt>
        SYMBOL_FORMALPARAM                = 206, // <Formal Param>
        SYMBOL_FORMALPARAMLIST            = 207, // <Formal Param List>
        SYMBOL_FORMALPARAMLISTOPT         = 208, // <Formal Param List Opt>
        SYMBOL_HEADER                     = 209, // <Header>
        SYMBOL_INDEXERDEC                 = 210, // <Indexer Dec>
        SYMBOL_INTEGRALTYPE               = 211, // <Integral Type>
        SYMBOL_INTERFACEACCESSORS         = 212, // <Interface Accessors>
        SYMBOL_INTERFACEBASEOPT           = 213, // <Interface Base Opt>
        SYMBOL_INTERFACEDECL              = 214, // <Interface Decl>
        SYMBOL_INTERFACEEMPTYBODY         = 215, // <Interface Empty Body>
        SYMBOL_INTERFACEEVENTDEC          = 216, // <Interface Event Dec>
        SYMBOL_INTERFACEINDEXERDEC        = 217, // <Interface Indexer Dec>
        SYMBOL_INTERFACEITEMDEC           = 218, // <Interface Item Dec>
        SYMBOL_INTERFACEITEMDECSOPT       = 219, // <Interface Item Decs Opt>
        SYMBOL_INTERFACEMETHODDEC         = 220, // <Interface Method Dec>
        SYMBOL_INTERFACEPROPERTYDEC       = 221, // <Interface Property Dec>
        SYMBOL_LITERAL                    = 222, // <Literal>
        SYMBOL_LOCALVARDECL               = 223, // <Local Var Decl>
        SYMBOL_LOGICALANDEXP              = 224, // <Logical And Exp>
        SYMBOL_LOGICALOREXP               = 225, // <Logical Or Exp>
        SYMBOL_LOGICALXOREXP              = 226, // <Logical Xor Exp>
        SYMBOL_MEMBERLIST                 = 227, // <Member List>
        SYMBOL_METHOD2                    = 228, // <Method>
        SYMBOL_METHODDEC                  = 229, // <Method Dec>
        SYMBOL_METHODEXP                  = 230, // <Method Exp>
        SYMBOL_METHODSOPT                 = 231, // <Methods Opt>
        SYMBOL_MODIFIER                   = 232, // <Modifier>
        SYMBOL_MODIFIERLISTOPT            = 233, // <Modifier List Opt>
        SYMBOL_MULTEXP                    = 234, // <Mult Exp>
        SYMBOL_NAMESPACEDEC               = 235, // <Namespace Dec>
        SYMBOL_NAMESPACEITEM              = 236, // <Namespace Item>
        SYMBOL_NAMESPACEITEMS             = 237, // <Namespace Items>
        SYMBOL_NEWOPT                     = 238, // <New Opt>
        SYMBOL_NONARRAYTYPE               = 239, // <Non Array Type>
        SYMBOL_NORMALSTM                  = 240, // <Normal Stm>
        SYMBOL_OBJECTEXP                  = 241, // <Object Exp>
        SYMBOL_OPERATORDEC                = 242, // <Operator Dec>
        SYMBOL_OREXP                      = 243, // <Or Exp>
        SYMBOL_OTHERTYPE                  = 244, // <Other Type>
        SYMBOL_OVERLOADOP                 = 245, // <Overload Op>
        SYMBOL_OVERLOADOPERATORDECL       = 246, // <Overload Operator Decl>
        SYMBOL_POINTEROPT                 = 247, // <Pointer Opt>
        SYMBOL_PRIMARY                    = 248, // <Primary>
        SYMBOL_PRIMARYARRAYCREATIONEXP    = 249, // <Primary Array Creation Exp>
        SYMBOL_PRIMARYEXP                 = 250, // <Primary Exp>
        SYMBOL_PROPERTYDEC                = 251, // <Property Dec>
        SYMBOL_QUALIFIEDID                = 252, // <Qualified ID>
        SYMBOL_RANKSPECIFIER              = 253, // <Rank Specifier>
        SYMBOL_RANKSPECIFIERS             = 254, // <Rank Specifiers>
        SYMBOL_RANKSPECIFIERSOPT          = 255, // <Rank Specifiers Opt>
        SYMBOL_RESOURCE                   = 256, // <Resource>
        SYMBOL_SEMICOLONOPT               = 257, // <Semicolon Opt>
        SYMBOL_SHIFTEXP                   = 258, // <Shift Exp>
        SYMBOL_STATEMENT                  = 259, // <Statement>
        SYMBOL_STATEMENTEXP               = 260, // <Statement Exp>
        SYMBOL_STATEMENTEXPLIST           = 261, // <Statement Exp List>
        SYMBOL_STMLIST                    = 262, // <Stm List>
        SYMBOL_STRUCTDECL                 = 263, // <Struct Decl>
        SYMBOL_SWITCHLABEL                = 264, // <Switch Label>
        SYMBOL_SWITCHLABELS               = 265, // <Switch Labels>
        SYMBOL_SWITCHSECTION              = 266, // <Switch Section>
        SYMBOL_SWITCHSECTIONSOPT          = 267, // <Switch Sections Opt>
        SYMBOL_THENSTM                    = 268, // <Then Stm>
        SYMBOL_TYPE2                      = 269, // <Type>
        SYMBOL_TYPEDECL                   = 270, // <Type Decl>
        SYMBOL_UNARYEXP                   = 271, // <Unary Exp>
        SYMBOL_USINGDIRECTIVE             = 272, // <Using Directive>
        SYMBOL_USINGLIST                  = 273, // <Using List>
        SYMBOL_VALIDID                    = 274, // <Valid ID>
        SYMBOL_VARIABLEDECLARATOR         = 275, // <Variable Declarator>
        SYMBOL_VARIABLEDECS               = 276, // <Variable Decs>
        SYMBOL_VARIABLEINITIALIZER        = 277, // <Variable Initializer>
        SYMBOL_VARIABLEINITIALIZERLIST    = 278, // <Variable Initializer List>
        SYMBOL_VARIABLEINITIALIZERLISTOPT = 279  // <Variable Initializer List Opt>
    };

    enum RuleConstants : int
    {
        RULE_BLOCKORSEMI                                                             =   0, // <Block or Semi> ::= <Block>
        RULE_BLOCKORSEMI_SEMI                                                        =   1, // <Block or Semi> ::= ';'
        RULE_VALIDID_IDENTIFIER                                                      =   2, // <Valid ID> ::= Identifier
        RULE_VALIDID_THIS                                                            =   3, // <Valid ID> ::= this
        RULE_VALIDID_BASE                                                            =   4, // <Valid ID> ::= base
        RULE_VALIDID                                                                 =   5, // <Valid ID> ::= <Base Type>
        RULE_QUALIFIEDID                                                             =   6, // <Qualified ID> ::= <Valid ID> <Member List>
        RULE_MEMBERLIST_MEMBERNAME                                                   =   7, // <Member List> ::= <Member List> MemberName
        RULE_MEMBERLIST                                                              =   8, // <Member List> ::= 
        RULE_SEMICOLONOPT_SEMI                                                       =   9, // <Semicolon Opt> ::= ';'
        RULE_SEMICOLONOPT                                                            =  10, // <Semicolon Opt> ::= 
        RULE_LITERAL_TRUE                                                            =  11, // <Literal> ::= true
        RULE_LITERAL_FALSE                                                           =  12, // <Literal> ::= false
        RULE_LITERAL_DECLITERAL                                                      =  13, // <Literal> ::= DecLiteral
        RULE_LITERAL_HEXLITERAL                                                      =  14, // <Literal> ::= HexLiteral
        RULE_LITERAL_REALLITERAL                                                     =  15, // <Literal> ::= RealLiteral
        RULE_LITERAL_CHARLITERAL                                                     =  16, // <Literal> ::= CharLiteral
        RULE_LITERAL_STRINGLITERAL                                                   =  17, // <Literal> ::= StringLiteral
        RULE_LITERAL_NULL                                                            =  18, // <Literal> ::= null
        RULE_TYPE                                                                    =  19, // <Type> ::= <Non Array Type>
        RULE_TYPE_TIMES                                                              =  20, // <Type> ::= <Non Array Type> '*'
        RULE_TYPE2                                                                   =  21, // <Type> ::= <Non Array Type> <Rank Specifiers>
        RULE_TYPE_TIMES2                                                             =  22, // <Type> ::= <Non Array Type> <Rank Specifiers> '*'
        RULE_POINTEROPT_TIMES                                                        =  23, // <Pointer Opt> ::= '*'
        RULE_POINTEROPT                                                              =  24, // <Pointer Opt> ::= 
        RULE_NONARRAYTYPE                                                            =  25, // <Non Array Type> ::= <Qualified ID>
        RULE_BASETYPE                                                                =  26, // <Base Type> ::= <Other Type>
        RULE_BASETYPE2                                                               =  27, // <Base Type> ::= <Integral Type>
        RULE_OTHERTYPE_FLOAT                                                         =  28, // <Other Type> ::= float
        RULE_OTHERTYPE_DOUBLE                                                        =  29, // <Other Type> ::= double
        RULE_OTHERTYPE_DECIMAL                                                       =  30, // <Other Type> ::= decimal
        RULE_OTHERTYPE_BOOL                                                          =  31, // <Other Type> ::= bool
        RULE_OTHERTYPE_VOID                                                          =  32, // <Other Type> ::= void
        RULE_OTHERTYPE_OBJECT                                                        =  33, // <Other Type> ::= object
        RULE_OTHERTYPE_STRING                                                        =  34, // <Other Type> ::= string
        RULE_INTEGRALTYPE_SBYTE                                                      =  35, // <Integral Type> ::= sbyte
        RULE_INTEGRALTYPE_BYTE                                                       =  36, // <Integral Type> ::= byte
        RULE_INTEGRALTYPE_SHORT                                                      =  37, // <Integral Type> ::= short
        RULE_INTEGRALTYPE_USHORT                                                     =  38, // <Integral Type> ::= ushort
        RULE_INTEGRALTYPE_INT                                                        =  39, // <Integral Type> ::= int
        RULE_INTEGRALTYPE_UINT                                                       =  40, // <Integral Type> ::= uint
        RULE_INTEGRALTYPE_LONG                                                       =  41, // <Integral Type> ::= long
        RULE_INTEGRALTYPE_ULONG                                                      =  42, // <Integral Type> ::= ulong
        RULE_INTEGRALTYPE_CHAR                                                       =  43, // <Integral Type> ::= char
        RULE_RANKSPECIFIERSOPT                                                       =  44, // <Rank Specifiers Opt> ::= <Rank Specifiers Opt> <Rank Specifier>
        RULE_RANKSPECIFIERSOPT2                                                      =  45, // <Rank Specifiers Opt> ::= 
        RULE_RANKSPECIFIERS                                                          =  46, // <Rank Specifiers> ::= <Rank Specifiers> <Rank Specifier>
        RULE_RANKSPECIFIERS2                                                         =  47, // <Rank Specifiers> ::= <Rank Specifier>
        RULE_RANKSPECIFIER_LBRACKET_RBRACKET                                         =  48, // <Rank Specifier> ::= '[' <Dim Separators> ']'
        RULE_DIMSEPARATORS_COMMA                                                     =  49, // <Dim Separators> ::= <Dim Separators> ','
        RULE_DIMSEPARATORS                                                           =  50, // <Dim Separators> ::= 
        RULE_EXPRESSIONOPT                                                           =  51, // <Expression Opt> ::= <Expression>
        RULE_EXPRESSIONOPT2                                                          =  52, // <Expression Opt> ::= 
        RULE_EXPRESSIONLIST                                                          =  53, // <Expression List> ::= <Expression>
        RULE_EXPRESSIONLIST_COMMA                                                    =  54, // <Expression List> ::= <Expression> ',' <Expression List>
        RULE_EXPRESSION_EQ                                                           =  55, // <Expression> ::= <Conditional Exp> '=' <Expression>
        RULE_EXPRESSION_PLUSEQ                                                       =  56, // <Expression> ::= <Conditional Exp> '+=' <Expression>
        RULE_EXPRESSION_MINUSEQ                                                      =  57, // <Expression> ::= <Conditional Exp> '-=' <Expression>
        RULE_EXPRESSION_TIMESEQ                                                      =  58, // <Expression> ::= <Conditional Exp> '*=' <Expression>
        RULE_EXPRESSION_DIVEQ                                                        =  59, // <Expression> ::= <Conditional Exp> '/=' <Expression>
        RULE_EXPRESSION_CARETEQ                                                      =  60, // <Expression> ::= <Conditional Exp> '^=' <Expression>
        RULE_EXPRESSION_AMPEQ                                                        =  61, // <Expression> ::= <Conditional Exp> '&=' <Expression>
        RULE_EXPRESSION_PIPEEQ                                                       =  62, // <Expression> ::= <Conditional Exp> '|=' <Expression>
        RULE_EXPRESSION_PERCENTEQ                                                    =  63, // <Expression> ::= <Conditional Exp> '%=' <Expression>
        RULE_EXPRESSION_LTLTEQ                                                       =  64, // <Expression> ::= <Conditional Exp> '<<=' <Expression>
        RULE_EXPRESSION_GTGTEQ                                                       =  65, // <Expression> ::= <Conditional Exp> '>>=' <Expression>
        RULE_EXPRESSION                                                              =  66, // <Expression> ::= <Conditional Exp>
        RULE_CONDITIONALEXP_QUESTION_COLON                                           =  67, // <Conditional Exp> ::= <Or Exp> '?' <Or Exp> ':' <Conditional Exp>
        RULE_CONDITIONALEXP                                                          =  68, // <Conditional Exp> ::= <Or Exp>
        RULE_OREXP_PIPEPIPE                                                          =  69, // <Or Exp> ::= <Or Exp> '||' <And Exp>
        RULE_OREXP                                                                   =  70, // <Or Exp> ::= <And Exp>
        RULE_ANDEXP_AMPAMP                                                           =  71, // <And Exp> ::= <And Exp> '&&' <Logical Or Exp>
        RULE_ANDEXP                                                                  =  72, // <And Exp> ::= <Logical Or Exp>
        RULE_LOGICALOREXP_PIPE                                                       =  73, // <Logical Or Exp> ::= <Logical Or Exp> '|' <Logical Xor Exp>
        RULE_LOGICALOREXP                                                            =  74, // <Logical Or Exp> ::= <Logical Xor Exp>
        RULE_LOGICALXOREXP_CARET                                                     =  75, // <Logical Xor Exp> ::= <Logical Xor Exp> '^' <Logical And Exp>
        RULE_LOGICALXOREXP                                                           =  76, // <Logical Xor Exp> ::= <Logical And Exp>
        RULE_LOGICALANDEXP_AMP                                                       =  77, // <Logical And Exp> ::= <Logical And Exp> '&' <Equality Exp>
        RULE_LOGICALANDEXP                                                           =  78, // <Logical And Exp> ::= <Equality Exp>
        RULE_EQUALITYEXP_EQEQ                                                        =  79, // <Equality Exp> ::= <Equality Exp> '==' <Compare Exp>
        RULE_EQUALITYEXP_EXCLAMEQ                                                    =  80, // <Equality Exp> ::= <Equality Exp> '!=' <Compare Exp>
        RULE_EQUALITYEXP                                                             =  81, // <Equality Exp> ::= <Compare Exp>
        RULE_COMPAREEXP_LT                                                           =  82, // <Compare Exp> ::= <Compare Exp> '<' <Shift Exp>
        RULE_COMPAREEXP_GT                                                           =  83, // <Compare Exp> ::= <Compare Exp> '>' <Shift Exp>
        RULE_COMPAREEXP_LTEQ                                                         =  84, // <Compare Exp> ::= <Compare Exp> '<=' <Shift Exp>
        RULE_COMPAREEXP_GTEQ                                                         =  85, // <Compare Exp> ::= <Compare Exp> '>=' <Shift Exp>
        RULE_COMPAREEXP_IS                                                           =  86, // <Compare Exp> ::= <Compare Exp> is <Type>
        RULE_COMPAREEXP_AS                                                           =  87, // <Compare Exp> ::= <Compare Exp> as <Type>
        RULE_COMPAREEXP                                                              =  88, // <Compare Exp> ::= <Shift Exp>
        RULE_SHIFTEXP_LTLT                                                           =  89, // <Shift Exp> ::= <Shift Exp> '<<' <Add Exp>
        RULE_SHIFTEXP_GTGT                                                           =  90, // <Shift Exp> ::= <Shift Exp> '>>' <Add Exp>
        RULE_SHIFTEXP                                                                =  91, // <Shift Exp> ::= <Add Exp>
        RULE_ADDEXP_PLUS                                                             =  92, // <Add Exp> ::= <Add Exp> '+' <Mult Exp>
        RULE_ADDEXP_MINUS                                                            =  93, // <Add Exp> ::= <Add Exp> '-' <Mult Exp>
        RULE_ADDEXP                                                                  =  94, // <Add Exp> ::= <Mult Exp>
        RULE_MULTEXP_TIMES                                                           =  95, // <Mult Exp> ::= <Mult Exp> '*' <Unary Exp>
        RULE_MULTEXP_DIV                                                             =  96, // <Mult Exp> ::= <Mult Exp> '/' <Unary Exp>
        RULE_MULTEXP_PERCENT                                                         =  97, // <Mult Exp> ::= <Mult Exp> '%' <Unary Exp>
        RULE_MULTEXP                                                                 =  98, // <Mult Exp> ::= <Unary Exp>
        RULE_UNARYEXP_EXCLAM                                                         =  99, // <Unary Exp> ::= '!' <Unary Exp>
        RULE_UNARYEXP_TILDE                                                          = 100, // <Unary Exp> ::= '~' <Unary Exp>
        RULE_UNARYEXP_MINUS                                                          = 101, // <Unary Exp> ::= '-' <Unary Exp>
        RULE_UNARYEXP_PLUSPLUS                                                       = 102, // <Unary Exp> ::= '++' <Unary Exp>
        RULE_UNARYEXP_MINUSMINUS                                                     = 103, // <Unary Exp> ::= -- <Unary Exp>
        RULE_UNARYEXP_LPARAN_RPARAN                                                  = 104, // <Unary Exp> ::= '(' <Expression> ')' <Object Exp>
        RULE_UNARYEXP                                                                = 105, // <Unary Exp> ::= <Object Exp>
        RULE_OBJECTEXP_DELEGATE_LPARAN_RPARAN                                        = 106, // <Object Exp> ::= delegate '(' <Formal Param List Opt> ')' <Block>
        RULE_OBJECTEXP                                                               = 107, // <Object Exp> ::= <Primary Array Creation Exp>
        RULE_OBJECTEXP2                                                              = 108, // <Object Exp> ::= <Method Exp>
        RULE_PRIMARYARRAYCREATIONEXP_NEW_LBRACKET_RBRACKET                           = 109, // <Primary Array Creation Exp> ::= new <Non Array Type> '[' <Expression List> ']' <Rank Specifiers Opt> <Array Initializer Opt>
        RULE_PRIMARYARRAYCREATIONEXP_NEW                                             = 110, // <Primary Array Creation Exp> ::= new <Non Array Type> <Rank Specifiers> <Array Initializer>
        RULE_METHODEXP                                                               = 111, // <Method Exp> ::= <Method Exp> <Method>
        RULE_METHODEXP2                                                              = 112, // <Method Exp> ::= <Primary Exp>
        RULE_PRIMARYEXP_TYPEOF_LPARAN_RPARAN                                         = 113, // <Primary Exp> ::= typeof '(' <Type> ')'
        RULE_PRIMARYEXP_SIZEOF_LPARAN_RPARAN                                         = 114, // <Primary Exp> ::= sizeof '(' <Type> ')'
        RULE_PRIMARYEXP_CHECKED_LPARAN_RPARAN                                        = 115, // <Primary Exp> ::= checked '(' <Expression> ')'
        RULE_PRIMARYEXP_UNCHECKED_LPARAN_RPARAN                                      = 116, // <Primary Exp> ::= unchecked '(' <Expression> ')'
        RULE_PRIMARYEXP_NEW_LPARAN_RPARAN                                            = 117, // <Primary Exp> ::= new <Non Array Type> '(' <Arg List Opt> ')'
        RULE_PRIMARYEXP                                                              = 118, // <Primary Exp> ::= <Primary>
        RULE_PRIMARYEXP_LPARAN_RPARAN                                                = 119, // <Primary Exp> ::= '(' <Expression> ')'
        RULE_PRIMARY                                                                 = 120, // <Primary> ::= <Valid ID>
        RULE_PRIMARY_LPARAN_RPARAN                                                   = 121, // <Primary> ::= <Valid ID> '(' <Arg List Opt> ')'
        RULE_PRIMARY2                                                                = 122, // <Primary> ::= <Literal>
        RULE_ARGLISTOPT                                                              = 123, // <Arg List Opt> ::= <Arg List>
        RULE_ARGLISTOPT2                                                             = 124, // <Arg List Opt> ::= 
        RULE_ARGLIST_COMMA                                                           = 125, // <Arg List> ::= <Arg List> ',' <Argument>
        RULE_ARGLIST                                                                 = 126, // <Arg List> ::= <Argument>
        RULE_ARGUMENT                                                                = 127, // <Argument> ::= <Expression>
        RULE_ARGUMENT_REF                                                            = 128, // <Argument> ::= ref <Expression>
        RULE_ARGUMENT_OUT                                                            = 129, // <Argument> ::= out <Expression>
        RULE_STMLIST                                                                 = 130, // <Stm List> ::= <Stm List> <Statement>
        RULE_STMLIST2                                                                = 131, // <Stm List> ::= <Statement>
        RULE_STATEMENT_IDENTIFIER_COLON                                              = 132, // <Statement> ::= Identifier ':'
        RULE_STATEMENT_SEMI                                                          = 133, // <Statement> ::= <Local Var Decl> ';'
        RULE_STATEMENT_IF_LPARAN_RPARAN                                              = 134, // <Statement> ::= if '(' <Expression> ')' <Statement>
        RULE_STATEMENT_IF_LPARAN_RPARAN_ELSE                                         = 135, // <Statement> ::= if '(' <Expression> ')' <Then Stm> else <Statement>
        RULE_STATEMENT_FOR_LPARAN_SEMI_SEMI_RPARAN                                   = 136, // <Statement> ::= for '(' <For Init Opt> ';' <For Condition Opt> ';' <For Iterator Opt> ')' <Statement>
        RULE_STATEMENT_FOREACH_LPARAN_IDENTIFIER_IN_RPARAN                           = 137, // <Statement> ::= foreach '(' <Type> Identifier in <Expression> ')' <Statement>
        RULE_STATEMENT_WHILE_LPARAN_RPARAN                                           = 138, // <Statement> ::= while '(' <Expression> ')' <Statement>
        RULE_STATEMENT_LOCK_LPARAN_RPARAN                                            = 139, // <Statement> ::= lock '(' <Expression> ')' <Statement>
        RULE_STATEMENT_USING_LPARAN_RPARAN                                           = 140, // <Statement> ::= using '(' <Resource> ')' <Statement>
        RULE_STATEMENT_FIXED_LPARAN_RPARAN                                           = 141, // <Statement> ::= fixed '(' <Type> <Fixed Ptr Decs> ')' <Statement>
        RULE_STATEMENT_DELEGATE_LPARAN_RPARAN                                        = 142, // <Statement> ::= delegate '(' <Formal Param List Opt> ')' <Statement>
        RULE_STATEMENT                                                               = 143, // <Statement> ::= <Normal Stm>
        RULE_THENSTM_IF_LPARAN_RPARAN_ELSE                                           = 144, // <Then Stm> ::= if '(' <Expression> ')' <Then Stm> else <Then Stm>
        RULE_THENSTM_FOR_LPARAN_SEMI_SEMI_RPARAN                                     = 145, // <Then Stm> ::= for '(' <For Init Opt> ';' <For Condition Opt> ';' <For Iterator Opt> ')' <Then Stm>
        RULE_THENSTM_FOREACH_LPARAN_IDENTIFIER_IN_RPARAN                             = 146, // <Then Stm> ::= foreach '(' <Type> Identifier in <Expression> ')' <Then Stm>
        RULE_THENSTM_WHILE_LPARAN_RPARAN                                             = 147, // <Then Stm> ::= while '(' <Expression> ')' <Then Stm>
        RULE_THENSTM_LOCK_LPARAN_RPARAN                                              = 148, // <Then Stm> ::= lock '(' <Expression> ')' <Then Stm>
        RULE_THENSTM_USING_LPARAN_RPARAN                                             = 149, // <Then Stm> ::= using '(' <Resource> ')' <Then Stm>
        RULE_THENSTM_FIXED_LPARAN_RPARAN                                             = 150, // <Then Stm> ::= fixed '(' <Type> <Fixed Ptr Decs> ')' <Then Stm>
        RULE_THENSTM_DELEGATE_LPARAN_RPARAN                                          = 151, // <Then Stm> ::= delegate '(' <Formal Param List Opt> ')' <Then Stm>
        RULE_THENSTM                                                                 = 152, // <Then Stm> ::= <Normal Stm>
        RULE_NORMALSTM_SWITCH_LPARAN_RPARAN_LBRACE_RBRACE                            = 153, // <Normal Stm> ::= switch '(' <Expression> ')' '{' <Switch Sections Opt> '}'
        RULE_NORMALSTM_DO_WHILE_LPARAN_RPARAN_SEMI                                   = 154, // <Normal Stm> ::= do <Normal Stm> while '(' <Expression> ')' ';'
        RULE_NORMALSTM_TRY                                                           = 155, // <Normal Stm> ::= try <Block> <Catch Clauses> <Finally Clause Opt>
        RULE_NORMALSTM_CHECKED                                                       = 156, // <Normal Stm> ::= checked <Block>
        RULE_NORMALSTM_UNCHECKED                                                     = 157, // <Normal Stm> ::= unchecked <Block>
        RULE_NORMALSTM_UNSAFE                                                        = 158, // <Normal Stm> ::= unsafe <Block>
        RULE_NORMALSTM_BREAK_SEMI                                                    = 159, // <Normal Stm> ::= break ';'
        RULE_NORMALSTM_CONTINUE_SEMI                                                 = 160, // <Normal Stm> ::= continue ';'
        RULE_NORMALSTM_GOTO_IDENTIFIER_SEMI                                          = 161, // <Normal Stm> ::= goto Identifier ';'
        RULE_NORMALSTM_GOTO_CASE_SEMI                                                = 162, // <Normal Stm> ::= goto case <Expression> ';'
        RULE_NORMALSTM_GOTO_DEFAULT_SEMI                                             = 163, // <Normal Stm> ::= goto default ';'
        RULE_NORMALSTM_RETURN_SEMI                                                   = 164, // <Normal Stm> ::= return <Expression Opt> ';'
        RULE_NORMALSTM_THROW_SEMI                                                    = 165, // <Normal Stm> ::= throw <Expression Opt> ';'
        RULE_NORMALSTM_SEMI                                                          = 166, // <Normal Stm> ::= <Statement Exp> ';'
        RULE_NORMALSTM_SEMI2                                                         = 167, // <Normal Stm> ::= ';'
        RULE_NORMALSTM                                                               = 168, // <Normal Stm> ::= <Block>
        RULE_BLOCK_LBRACE_RBRACE                                                     = 169, // <Block> ::= '{' <Stm List> '}'
        RULE_BLOCK_LBRACE_RBRACE2                                                    = 170, // <Block> ::= '{' '}'
        RULE_VARIABLEDECS                                                            = 171, // <Variable Decs> ::= <Variable Declarator>
        RULE_VARIABLEDECS_COMMA                                                      = 172, // <Variable Decs> ::= <Variable Decs> ',' <Variable Declarator>
        RULE_VARIABLEDECLARATOR_IDENTIFIER                                           = 173, // <Variable Declarator> ::= Identifier
        RULE_VARIABLEDECLARATOR_IDENTIFIER_EQ                                        = 174, // <Variable Declarator> ::= Identifier '=' <Variable Initializer>
        RULE_VARIABLEINITIALIZER                                                     = 175, // <Variable Initializer> ::= <Expression>
        RULE_VARIABLEINITIALIZER2                                                    = 176, // <Variable Initializer> ::= <Array Initializer>
        RULE_VARIABLEINITIALIZER_STACKALLOC_LBRACKET_RBRACKET                        = 177, // <Variable Initializer> ::= stackalloc <Non Array Type> '[' <Non Array Type> ']'
        RULE_CONSTANTDECLARATORS                                                     = 178, // <Constant Declarators> ::= <Constant Declarator>
        RULE_CONSTANTDECLARATORS_COMMA                                               = 179, // <Constant Declarators> ::= <Constant Declarators> ',' <Constant Declarator>
        RULE_CONSTANTDECLARATOR_IDENTIFIER_EQ                                        = 180, // <Constant Declarator> ::= Identifier '=' <Expression>
        RULE_SWITCHSECTIONSOPT                                                       = 181, // <Switch Sections Opt> ::= <Switch Sections Opt> <Switch Section>
        RULE_SWITCHSECTIONSOPT2                                                      = 182, // <Switch Sections Opt> ::= 
        RULE_SWITCHSECTION                                                           = 183, // <Switch Section> ::= <Switch Labels> <Stm List>
        RULE_SWITCHLABELS                                                            = 184, // <Switch Labels> ::= <Switch Label>
        RULE_SWITCHLABELS2                                                           = 185, // <Switch Labels> ::= <Switch Labels> <Switch Label>
        RULE_SWITCHLABEL_CASE_COLON                                                  = 186, // <Switch Label> ::= case <Expression> ':'
        RULE_SWITCHLABEL_DEFAULT_COLON                                               = 187, // <Switch Label> ::= default ':'
        RULE_FORINITOPT                                                              = 188, // <For Init Opt> ::= <Local Var Decl>
        RULE_FORINITOPT2                                                             = 189, // <For Init Opt> ::= <Statement Exp List>
        RULE_FORINITOPT3                                                             = 190, // <For Init Opt> ::= 
        RULE_FORITERATOROPT                                                          = 191, // <For Iterator Opt> ::= <Statement Exp List>
        RULE_FORITERATOROPT2                                                         = 192, // <For Iterator Opt> ::= 
        RULE_FORCONDITIONOPT                                                         = 193, // <For Condition Opt> ::= <Expression>
        RULE_FORCONDITIONOPT2                                                        = 194, // <For Condition Opt> ::= 
        RULE_STATEMENTEXPLIST_COMMA                                                  = 195, // <Statement Exp List> ::= <Statement Exp List> ',' <Statement Exp>
        RULE_STATEMENTEXPLIST                                                        = 196, // <Statement Exp List> ::= <Statement Exp>
        RULE_CATCHCLAUSES                                                            = 197, // <Catch Clauses> ::= <Catch Clause> <Catch Clauses>
        RULE_CATCHCLAUSES2                                                           = 198, // <Catch Clauses> ::= 
        RULE_CATCHCLAUSE_CATCH_LPARAN_IDENTIFIER_RPARAN                              = 199, // <Catch Clause> ::= catch '(' <Qualified ID> Identifier ')' <Block>
        RULE_CATCHCLAUSE_CATCH_LPARAN_RPARAN                                         = 200, // <Catch Clause> ::= catch '(' <Qualified ID> ')' <Block>
        RULE_CATCHCLAUSE_CATCH                                                       = 201, // <Catch Clause> ::= catch <Block>
        RULE_FINALLYCLAUSEOPT_FINALLY                                                = 202, // <Finally Clause Opt> ::= finally <Block>
        RULE_FINALLYCLAUSEOPT                                                        = 203, // <Finally Clause Opt> ::= 
        RULE_RESOURCE                                                                = 204, // <Resource> ::= <Local Var Decl>
        RULE_RESOURCE2                                                               = 205, // <Resource> ::= <Statement Exp>
        RULE_FIXEDPTRDECS                                                            = 206, // <Fixed Ptr Decs> ::= <Fixed Ptr Dec>
        RULE_FIXEDPTRDECS_COMMA                                                      = 207, // <Fixed Ptr Decs> ::= <Fixed Ptr Decs> ',' <Fixed Ptr Dec>
        RULE_FIXEDPTRDEC_IDENTIFIER_EQ                                               = 208, // <Fixed Ptr Dec> ::= Identifier '=' <Expression>
        RULE_LOCALVARDECL                                                            = 209, // <Local Var Decl> ::= <Qualified ID> <Rank Specifiers> <Pointer Opt> <Variable Decs>
        RULE_LOCALVARDECL2                                                           = 210, // <Local Var Decl> ::= <Qualified ID> <Pointer Opt> <Variable Decs>
        RULE_STATEMENTEXP_LPARAN_RPARAN                                              = 211, // <Statement Exp> ::= <Qualified ID> '(' <Arg List Opt> ')'
        RULE_STATEMENTEXP_LPARAN_RPARAN2                                             = 212, // <Statement Exp> ::= <Qualified ID> '(' <Arg List Opt> ')' <Methods Opt> <Assign Tail>
        RULE_STATEMENTEXP_LBRACKET_RBRACKET                                          = 213, // <Statement Exp> ::= <Qualified ID> '[' <Expression List> ']' <Methods Opt> <Assign Tail>
        RULE_STATEMENTEXP_MINUSGT_IDENTIFIER                                         = 214, // <Statement Exp> ::= <Qualified ID> '->' Identifier <Methods Opt> <Assign Tail>
        RULE_STATEMENTEXP_PLUSPLUS                                                   = 215, // <Statement Exp> ::= <Qualified ID> '++' <Methods Opt> <Assign Tail>
        RULE_STATEMENTEXP_MINUSMINUS                                                 = 216, // <Statement Exp> ::= <Qualified ID> -- <Methods Opt> <Assign Tail>
        RULE_STATEMENTEXP                                                            = 217, // <Statement Exp> ::= <Qualified ID> <Assign Tail>
        RULE_ASSIGNTAIL_PLUSPLUS                                                     = 218, // <Assign Tail> ::= '++'
        RULE_ASSIGNTAIL_MINUSMINUS                                                   = 219, // <Assign Tail> ::= --
        RULE_ASSIGNTAIL_EQ                                                           = 220, // <Assign Tail> ::= '=' <Expression>
        RULE_ASSIGNTAIL_PLUSEQ                                                       = 221, // <Assign Tail> ::= '+=' <Expression>
        RULE_ASSIGNTAIL_MINUSEQ                                                      = 222, // <Assign Tail> ::= '-=' <Expression>
        RULE_ASSIGNTAIL_TIMESEQ                                                      = 223, // <Assign Tail> ::= '*=' <Expression>
        RULE_ASSIGNTAIL_DIVEQ                                                        = 224, // <Assign Tail> ::= '/=' <Expression>
        RULE_ASSIGNTAIL_CARETEQ                                                      = 225, // <Assign Tail> ::= '^=' <Expression>
        RULE_ASSIGNTAIL_AMPEQ                                                        = 226, // <Assign Tail> ::= '&=' <Expression>
        RULE_ASSIGNTAIL_PIPEEQ                                                       = 227, // <Assign Tail> ::= '|=' <Expression>
        RULE_ASSIGNTAIL_PERCENTEQ                                                    = 228, // <Assign Tail> ::= '%=' <Expression>
        RULE_ASSIGNTAIL_LTLTEQ                                                       = 229, // <Assign Tail> ::= '<<=' <Expression>
        RULE_ASSIGNTAIL_GTGTEQ                                                       = 230, // <Assign Tail> ::= '>>=' <Expression>
        RULE_METHODSOPT                                                              = 231, // <Methods Opt> ::= <Methods Opt> <Method>
        RULE_METHODSOPT2                                                             = 232, // <Methods Opt> ::= 
        RULE_METHOD_MEMBERNAME                                                       = 233, // <Method> ::= MemberName
        RULE_METHOD_MEMBERNAME_LPARAN_RPARAN                                         = 234, // <Method> ::= MemberName '(' <Arg List Opt> ')'
        RULE_METHOD_LBRACKET_RBRACKET                                                = 235, // <Method> ::= '[' <Expression List> ']'
        RULE_METHOD_MINUSGT_IDENTIFIER                                               = 236, // <Method> ::= '->' Identifier
        RULE_METHOD_PLUSPLUS                                                         = 237, // <Method> ::= '++'
        RULE_METHOD_MINUSMINUS                                                       = 238, // <Method> ::= --
        RULE_COMPILATIONUNIT                                                         = 239, // <Compilation Unit> ::= <Using List> <Compilation Items>
        RULE_USINGLIST                                                               = 240, // <Using List> ::= <Using List> <Using Directive>
        RULE_USINGLIST2                                                              = 241, // <Using List> ::= 
        RULE_USINGDIRECTIVE_USING_IDENTIFIER_EQ_SEMI                                 = 242, // <Using Directive> ::= using Identifier '=' <Qualified ID> ';'
        RULE_USINGDIRECTIVE_USING_SEMI                                               = 243, // <Using Directive> ::= using <Qualified ID> ';'
        RULE_COMPILATIONITEMS                                                        = 244, // <Compilation Items> ::= <Compilation Items> <Compilation Item>
        RULE_COMPILATIONITEMS2                                                       = 245, // <Compilation Items> ::= 
        RULE_COMPILATIONITEM                                                         = 246, // <Compilation Item> ::= <Namespace Dec>
        RULE_COMPILATIONITEM2                                                        = 247, // <Compilation Item> ::= <Namespace Item>
        RULE_NAMESPACEDEC_NAMESPACE_LBRACE_RBRACE                                    = 248, // <Namespace Dec> ::= <Attrib Opt> namespace <Qualified ID> '{' <Using List> <Namespace Items> '}' <Semicolon Opt>
        RULE_NAMESPACEITEMS                                                          = 249, // <Namespace Items> ::= <Namespace Items> <Namespace Item>
        RULE_NAMESPACEITEMS2                                                         = 250, // <Namespace Items> ::= 
        RULE_NAMESPACEITEM                                                           = 251, // <Namespace Item> ::= <Constant Dec>
        RULE_NAMESPACEITEM2                                                          = 252, // <Namespace Item> ::= <Field Dec>
        RULE_NAMESPACEITEM3                                                          = 253, // <Namespace Item> ::= <Method Dec>
        RULE_NAMESPACEITEM4                                                          = 254, // <Namespace Item> ::= <Property Dec>
        RULE_NAMESPACEITEM5                                                          = 255, // <Namespace Item> ::= <Type Decl>
        RULE_TYPEDECL                                                                = 256, // <Type Decl> ::= <Class Decl>
        RULE_TYPEDECL2                                                               = 257, // <Type Decl> ::= <Struct Decl>
        RULE_TYPEDECL3                                                               = 258, // <Type Decl> ::= <Interface Decl>
        RULE_TYPEDECL4                                                               = 259, // <Type Decl> ::= <Enum Decl>
        RULE_TYPEDECL5                                                               = 260, // <Type Decl> ::= <Delegate Decl>
        RULE_HEADER                                                                  = 261, // <Header> ::= <Attrib Opt> <Access Opt> <Modifier List Opt>
        RULE_ACCESSOPT_PRIVATE                                                       = 262, // <Access Opt> ::= private
        RULE_ACCESSOPT_PROTECTED                                                     = 263, // <Access Opt> ::= protected
        RULE_ACCESSOPT_PUBLIC                                                        = 264, // <Access Opt> ::= public
        RULE_ACCESSOPT_INTERNAL                                                      = 265, // <Access Opt> ::= internal
        RULE_ACCESSOPT                                                               = 266, // <Access Opt> ::= 
        RULE_MODIFIERLISTOPT                                                         = 267, // <Modifier List Opt> ::= <Modifier List Opt> <Modifier>
        RULE_MODIFIERLISTOPT2                                                        = 268, // <Modifier List Opt> ::= 
        RULE_MODIFIER_ABSTRACT                                                       = 269, // <Modifier> ::= abstract
        RULE_MODIFIER_EXTERN                                                         = 270, // <Modifier> ::= extern
        RULE_MODIFIER_NEW                                                            = 271, // <Modifier> ::= new
        RULE_MODIFIER_OVERRIDE                                                       = 272, // <Modifier> ::= override
        RULE_MODIFIER_PARTIAL                                                        = 273, // <Modifier> ::= partial
        RULE_MODIFIER_READONLY                                                       = 274, // <Modifier> ::= readonly
        RULE_MODIFIER_SEALED                                                         = 275, // <Modifier> ::= sealed
        RULE_MODIFIER_STATIC                                                         = 276, // <Modifier> ::= static
        RULE_MODIFIER_UNSAFE                                                         = 277, // <Modifier> ::= unsafe
        RULE_MODIFIER_VIRTUAL                                                        = 278, // <Modifier> ::= virtual
        RULE_MODIFIER_VOLATILE                                                       = 279, // <Modifier> ::= volatile
        RULE_CLASSDECL_CLASS_IDENTIFIER_LBRACE_RBRACE                                = 280, // <Class Decl> ::= <Header> class Identifier <Class Base Opt> '{' <Class Item Decs Opt> '}' <Semicolon Opt>
        RULE_CLASSBASEOPT_COLON                                                      = 281, // <Class Base Opt> ::= ':' <Class Base List>
        RULE_CLASSBASEOPT                                                            = 282, // <Class Base Opt> ::= 
        RULE_CLASSBASELIST_COMMA                                                     = 283, // <Class Base List> ::= <Class Base List> ',' <Non Array Type>
        RULE_CLASSBASELIST                                                           = 284, // <Class Base List> ::= <Non Array Type>
        RULE_CLASSITEMDECSOPT                                                        = 285, // <Class Item Decs Opt> ::= <Class Item Decs Opt> <Class Item>
        RULE_CLASSITEMDECSOPT2                                                       = 286, // <Class Item Decs Opt> ::= 
        RULE_CLASSITEM                                                               = 287, // <Class Item> ::= <Constant Dec>
        RULE_CLASSITEM2                                                              = 288, // <Class Item> ::= <Field Dec>
        RULE_CLASSITEM3                                                              = 289, // <Class Item> ::= <Method Dec>
        RULE_CLASSITEM4                                                              = 290, // <Class Item> ::= <Property Dec>
        RULE_CLASSITEM5                                                              = 291, // <Class Item> ::= <Event Dec>
        RULE_CLASSITEM6                                                              = 292, // <Class Item> ::= <Indexer Dec>
        RULE_CLASSITEM7                                                              = 293, // <Class Item> ::= <Operator Dec>
        RULE_CLASSITEM8                                                              = 294, // <Class Item> ::= <Constructor Dec>
        RULE_CLASSITEM9                                                              = 295, // <Class Item> ::= <Destructor Dec>
        RULE_CLASSITEM10                                                             = 296, // <Class Item> ::= <Type Decl>
        RULE_CONSTANTDEC_CONST_SEMI                                                  = 297, // <Constant Dec> ::= <Header> const <Type> <Constant Declarators> ';'
        RULE_FIELDDEC_SEMI                                                           = 298, // <Field Dec> ::= <Header> <Type> <Variable Decs> ';'
        RULE_METHODDEC_LPARAN_RPARAN                                                 = 299, // <Method Dec> ::= <Header> <Type> <Qualified ID> '(' <Formal Param List Opt> ')' <Block or Semi>
        RULE_FORMALPARAMLISTOPT                                                      = 300, // <Formal Param List Opt> ::= <Formal Param List>
        RULE_FORMALPARAMLISTOPT2                                                     = 301, // <Formal Param List Opt> ::= 
        RULE_FORMALPARAMLIST                                                         = 302, // <Formal Param List> ::= <Formal Param>
        RULE_FORMALPARAMLIST_COMMA                                                   = 303, // <Formal Param List> ::= <Formal Param List> ',' <Formal Param>
        RULE_FORMALPARAM_IDENTIFIER                                                  = 304, // <Formal Param> ::= <Attrib Opt> <Type> Identifier
        RULE_FORMALPARAM_REF_IDENTIFIER                                              = 305, // <Formal Param> ::= <Attrib Opt> ref <Type> Identifier
        RULE_FORMALPARAM_OUT_IDENTIFIER                                              = 306, // <Formal Param> ::= <Attrib Opt> out <Type> Identifier
        RULE_FORMALPARAM_PARAMS_IDENTIFIER                                           = 307, // <Formal Param> ::= <Attrib Opt> params <Type> Identifier
        RULE_PROPERTYDEC_LBRACE_RBRACE                                               = 308, // <Property Dec> ::= <Header> <Type> <Qualified ID> '{' <Accessor Dec> '}'
        RULE_ACCESSORDEC_GET                                                         = 309, // <Accessor Dec> ::= <Access Opt> get <Block or Semi>
        RULE_ACCESSORDEC_GET_SET                                                     = 310, // <Accessor Dec> ::= <Access Opt> get <Block or Semi> <Access Opt> set <Block or Semi>
        RULE_ACCESSORDEC_SET                                                         = 311, // <Accessor Dec> ::= <Access Opt> set <Block or Semi>
        RULE_ACCESSORDEC_SET_GET                                                     = 312, // <Accessor Dec> ::= <Access Opt> set <Block or Semi> <Access Opt> get <Block or Semi>
        RULE_EVENTDEC_EVENT_SEMI                                                     = 313, // <Event Dec> ::= <Header> event <Type> <Variable Decs> ';'
        RULE_EVENTDEC_EVENT_LBRACE_RBRACE                                            = 314, // <Event Dec> ::= <Header> event <Type> <Qualified ID> '{' <Event Accessor Decs> '}'
        RULE_EVENTACCESSORDECS_ADD                                                   = 315, // <Event Accessor Decs> ::= add <Block or Semi>
        RULE_EVENTACCESSORDECS_ADD_REMOVE                                            = 316, // <Event Accessor Decs> ::= add <Block or Semi> remove <Block or Semi>
        RULE_EVENTACCESSORDECS_REMOVE                                                = 317, // <Event Accessor Decs> ::= remove <Block or Semi>
        RULE_EVENTACCESSORDECS_REMOVE_ADD                                            = 318, // <Event Accessor Decs> ::= remove <Block or Semi> add <Block or Semi>
        RULE_INDEXERDEC_LBRACKET_RBRACKET_LBRACE_RBRACE                              = 319, // <Indexer Dec> ::= <Header> <Type> <Qualified ID> '[' <Formal Param List> ']' '{' <Accessor Dec> '}'
        RULE_OPERATORDEC                                                             = 320, // <Operator Dec> ::= <Header> <Overload Operator Decl> <Block or Semi>
        RULE_OPERATORDEC2                                                            = 321, // <Operator Dec> ::= <Header> <Conversion Operator Decl> <Block or Semi>
        RULE_OVERLOADOPERATORDECL_OPERATOR_LPARAN_IDENTIFIER_RPARAN                  = 322, // <Overload Operator Decl> ::= <Type> operator <Overload Op> '(' <Type> Identifier ')'
        RULE_OVERLOADOPERATORDECL_OPERATOR_LPARAN_IDENTIFIER_COMMA_IDENTIFIER_RPARAN = 323, // <Overload Operator Decl> ::= <Type> operator <Overload Op> '(' <Type> Identifier ',' <Type> Identifier ')'
        RULE_CONVERSIONOPERATORDECL_IMPLICIT_OPERATOR_LPARAN_IDENTIFIER_RPARAN       = 324, // <Conversion Operator Decl> ::= implicit operator <Type> '(' <Type> Identifier ')'
        RULE_CONVERSIONOPERATORDECL_EXPLICIT_OPERATOR_LPARAN_IDENTIFIER_RPARAN       = 325, // <Conversion Operator Decl> ::= explicit operator <Type> '(' <Type> Identifier ')'
        RULE_OVERLOADOP_PLUS                                                         = 326, // <Overload Op> ::= '+'
        RULE_OVERLOADOP_MINUS                                                        = 327, // <Overload Op> ::= '-'
        RULE_OVERLOADOP_EXCLAM                                                       = 328, // <Overload Op> ::= '!'
        RULE_OVERLOADOP_TILDE                                                        = 329, // <Overload Op> ::= '~'
        RULE_OVERLOADOP_PLUSPLUS                                                     = 330, // <Overload Op> ::= '++'
        RULE_OVERLOADOP_MINUSMINUS                                                   = 331, // <Overload Op> ::= --
        RULE_OVERLOADOP_TRUE                                                         = 332, // <Overload Op> ::= true
        RULE_OVERLOADOP_FALSE                                                        = 333, // <Overload Op> ::= false
        RULE_OVERLOADOP_TIMES                                                        = 334, // <Overload Op> ::= '*'
        RULE_OVERLOADOP_DIV                                                          = 335, // <Overload Op> ::= '/'
        RULE_OVERLOADOP_PERCENT                                                      = 336, // <Overload Op> ::= '%'
        RULE_OVERLOADOP_AMP                                                          = 337, // <Overload Op> ::= '&'
        RULE_OVERLOADOP_PIPE                                                         = 338, // <Overload Op> ::= '|'
        RULE_OVERLOADOP_CARET                                                        = 339, // <Overload Op> ::= '^'
        RULE_OVERLOADOP_LTLT                                                         = 340, // <Overload Op> ::= '<<'
        RULE_OVERLOADOP_GTGT                                                         = 341, // <Overload Op> ::= '>>'
        RULE_OVERLOADOP_EQEQ                                                         = 342, // <Overload Op> ::= '=='
        RULE_OVERLOADOP_EXCLAMEQ                                                     = 343, // <Overload Op> ::= '!='
        RULE_OVERLOADOP_GT                                                           = 344, // <Overload Op> ::= '>'
        RULE_OVERLOADOP_LT                                                           = 345, // <Overload Op> ::= '<'
        RULE_OVERLOADOP_GTEQ                                                         = 346, // <Overload Op> ::= '>='
        RULE_OVERLOADOP_LTEQ                                                         = 347, // <Overload Op> ::= '<='
        RULE_CONSTRUCTORDEC                                                          = 348, // <Constructor Dec> ::= <Header> <Constructor Declarator> <Block or Semi>
        RULE_CONSTRUCTORDECLARATOR_IDENTIFIER_LPARAN_RPARAN                          = 349, // <Constructor Declarator> ::= Identifier '(' <Formal Param List Opt> ')' <Constructor Init Opt>
        RULE_CONSTRUCTORINITOPT                                                      = 350, // <Constructor Init Opt> ::= <Constructor Init>
        RULE_CONSTRUCTORINITOPT2                                                     = 351, // <Constructor Init Opt> ::= 
        RULE_CONSTRUCTORINIT_COLON_BASE_LPARAN_RPARAN                                = 352, // <Constructor Init> ::= ':' base '(' <Arg List Opt> ')'
        RULE_CONSTRUCTORINIT_COLON_THIS_LPARAN_RPARAN                                = 353, // <Constructor Init> ::= ':' this '(' <Arg List Opt> ')'
        RULE_DESTRUCTORDEC_TILDE_IDENTIFIER_LPARAN_RPARAN                            = 354, // <Destructor Dec> ::= <Header> '~' Identifier '(' ')' <Block>
        RULE_STRUCTDECL_STRUCT_IDENTIFIER_LBRACE_RBRACE                              = 355, // <Struct Decl> ::= <Header> struct Identifier <Class Base Opt> '{' <Class Item Decs Opt> '}' <Semicolon Opt>
        RULE_ARRAYINITIALIZEROPT                                                     = 356, // <Array Initializer Opt> ::= <Array Initializer>
        RULE_ARRAYINITIALIZEROPT2                                                    = 357, // <Array Initializer Opt> ::= 
        RULE_ARRAYINITIALIZER_LBRACE_RBRACE                                          = 358, // <Array Initializer> ::= '{' <Variable Initializer List Opt> '}'
        RULE_ARRAYINITIALIZER_LBRACE_COMMA_RBRACE                                    = 359, // <Array Initializer> ::= '{' <Variable Initializer List> ',' '}'
        RULE_VARIABLEINITIALIZERLISTOPT                                              = 360, // <Variable Initializer List Opt> ::= <Variable Initializer List>
        RULE_VARIABLEINITIALIZERLISTOPT2                                             = 361, // <Variable Initializer List Opt> ::= 
        RULE_VARIABLEINITIALIZERLIST                                                 = 362, // <Variable Initializer List> ::= <Variable Initializer>
        RULE_VARIABLEINITIALIZERLIST_COMMA                                           = 363, // <Variable Initializer List> ::= <Variable Initializer List> ',' <Variable Initializer>
        RULE_INTERFACEDECL_INTERFACE_IDENTIFIER_LBRACE_RBRACE                        = 364, // <Interface Decl> ::= <Header> interface Identifier <Interface Base Opt> '{' <Interface Item Decs Opt> '}' <Semicolon Opt>
        RULE_INTERFACEBASEOPT_COLON                                                  = 365, // <Interface Base Opt> ::= ':' <Class Base List>
        RULE_INTERFACEBASEOPT                                                        = 366, // <Interface Base Opt> ::= 
        RULE_INTERFACEITEMDECSOPT                                                    = 367, // <Interface Item Decs Opt> ::= <Interface Item Decs Opt> <Interface Item Dec>
        RULE_INTERFACEITEMDECSOPT2                                                   = 368, // <Interface Item Decs Opt> ::= 
        RULE_INTERFACEITEMDEC                                                        = 369, // <Interface Item Dec> ::= <Interface Method Dec>
        RULE_INTERFACEITEMDEC2                                                       = 370, // <Interface Item Dec> ::= <Interface Property Dec>
        RULE_INTERFACEITEMDEC3                                                       = 371, // <Interface Item Dec> ::= <Interface Event Dec>
        RULE_INTERFACEITEMDEC4                                                       = 372, // <Interface Item Dec> ::= <Interface Indexer Dec>
        RULE_INTERFACEMETHODDEC_IDENTIFIER_LPARAN_RPARAN                             = 373, // <Interface Method Dec> ::= <Attrib Opt> <New Opt> <Type> Identifier '(' <Formal Param List Opt> ')' <Interface Empty Body>
        RULE_NEWOPT_NEW                                                              = 374, // <New Opt> ::= new
        RULE_NEWOPT                                                                  = 375, // <New Opt> ::= 
        RULE_INTERFACEPROPERTYDEC_IDENTIFIER_LBRACE_RBRACE                           = 376, // <Interface Property Dec> ::= <Attrib Opt> <New Opt> <Type> Identifier '{' <Interface Accessors> '}'
        RULE_INTERFACEINDEXERDEC_THIS_LBRACKET_RBRACKET_LBRACE_RBRACE                = 377, // <Interface Indexer Dec> ::= <Attrib Opt> <New Opt> <Type> this '[' <Formal Param List> ']' '{' <Interface Accessors> '}'
        RULE_INTERFACEACCESSORS_GET                                                  = 378, // <Interface Accessors> ::= <Attrib Opt> <Access Opt> get <Interface Empty Body>
        RULE_INTERFACEACCESSORS_SET                                                  = 379, // <Interface Accessors> ::= <Attrib Opt> <Access Opt> set <Interface Empty Body>
        RULE_INTERFACEACCESSORS_GET_SET                                              = 380, // <Interface Accessors> ::= <Attrib Opt> <Access Opt> get <Interface Empty Body> <Attrib Opt> <Access Opt> set <Interface Empty Body>
        RULE_INTERFACEACCESSORS_SET_GET                                              = 381, // <Interface Accessors> ::= <Attrib Opt> <Access Opt> set <Interface Empty Body> <Attrib Opt> <Access Opt> get <Interface Empty Body>
        RULE_INTERFACEEVENTDEC_EVENT_IDENTIFIER                                      = 382, // <Interface Event Dec> ::= <Attrib Opt> <New Opt> event <Type> Identifier <Interface Empty Body>
        RULE_INTERFACEEMPTYBODY_SEMI                                                 = 383, // <Interface Empty Body> ::= ';'
        RULE_INTERFACEEMPTYBODY_LBRACE_RBRACE                                        = 384, // <Interface Empty Body> ::= '{' '}'
        RULE_ENUMDECL_ENUM_IDENTIFIER                                                = 385, // <Enum Decl> ::= <Header> enum Identifier <Enum Base Opt> <Enum Body> <Semicolon Opt>
        RULE_ENUMBASEOPT_COLON                                                       = 386, // <Enum Base Opt> ::= ':' <Integral Type>
        RULE_ENUMBASEOPT                                                             = 387, // <Enum Base Opt> ::= 
        RULE_ENUMBODY_LBRACE_RBRACE                                                  = 388, // <Enum Body> ::= '{' <Enum Item Decs Opt> '}'
        RULE_ENUMBODY_LBRACE_COMMA_RBRACE                                            = 389, // <Enum Body> ::= '{' <Enum Item Decs> ',' '}'
        RULE_ENUMITEMDECSOPT                                                         = 390, // <Enum Item Decs Opt> ::= <Enum Item Decs>
        RULE_ENUMITEMDECSOPT2                                                        = 391, // <Enum Item Decs Opt> ::= 
        RULE_ENUMITEMDECS                                                            = 392, // <Enum Item Decs> ::= <Enum Item Dec>
        RULE_ENUMITEMDECS_COMMA                                                      = 393, // <Enum Item Decs> ::= <Enum Item Decs> ',' <Enum Item Dec>
        RULE_ENUMITEMDEC_IDENTIFIER                                                  = 394, // <Enum Item Dec> ::= <Attrib Opt> Identifier
        RULE_ENUMITEMDEC_IDENTIFIER_EQ                                               = 395, // <Enum Item Dec> ::= <Attrib Opt> Identifier '=' <Expression>
        RULE_DELEGATEDECL_DELEGATE_IDENTIFIER_LPARAN_RPARAN_SEMI                     = 396, // <Delegate Decl> ::= <Header> delegate <Type> Identifier '(' <Formal Param List Opt> ')' ';'
        RULE_ATTRIBOPT                                                               = 397, // <Attrib Opt> ::= <Attrib Opt> <Attrib Section>
        RULE_ATTRIBOPT2                                                              = 398, // <Attrib Opt> ::= 
        RULE_ATTRIBSECTION_LBRACKET_RBRACKET                                         = 399, // <Attrib Section> ::= '[' <Attrib Target Spec Opt> <Attrib List> ']'
        RULE_ATTRIBSECTION_LBRACKET_COMMA_RBRACKET                                   = 400, // <Attrib Section> ::= '[' <Attrib Target Spec Opt> <Attrib List> ',' ']'
        RULE_ATTRIBTARGETSPECOPT_ASSEMBLY_COLON                                      = 401, // <Attrib Target Spec Opt> ::= assembly ':'
        RULE_ATTRIBTARGETSPECOPT_FIELD_COLON                                         = 402, // <Attrib Target Spec Opt> ::= field ':'
        RULE_ATTRIBTARGETSPECOPT_EVENT_COLON                                         = 403, // <Attrib Target Spec Opt> ::= event ':'
        RULE_ATTRIBTARGETSPECOPT_METHOD_COLON                                        = 404, // <Attrib Target Spec Opt> ::= method ':'
        RULE_ATTRIBTARGETSPECOPT_MODULE_COLON                                        = 405, // <Attrib Target Spec Opt> ::= module ':'
        RULE_ATTRIBTARGETSPECOPT_PARAM_COLON                                         = 406, // <Attrib Target Spec Opt> ::= param ':'
        RULE_ATTRIBTARGETSPECOPT_PROPERTY_COLON                                      = 407, // <Attrib Target Spec Opt> ::= property ':'
        RULE_ATTRIBTARGETSPECOPT_RETURN_COLON                                        = 408, // <Attrib Target Spec Opt> ::= return ':'
        RULE_ATTRIBTARGETSPECOPT_TYPE_COLON                                          = 409, // <Attrib Target Spec Opt> ::= type ':'
        RULE_ATTRIBTARGETSPECOPT                                                     = 410, // <Attrib Target Spec Opt> ::= 
        RULE_ATTRIBLIST                                                              = 411, // <Attrib List> ::= <Attribute>
        RULE_ATTRIBLIST_COMMA                                                        = 412, // <Attrib List> ::= <Attrib List> ',' <Attribute>
        RULE_ATTRIBUTE_LPARAN_RPARAN                                                 = 413, // <Attribute> ::= <Qualified ID> '(' <Expression List> ')'
        RULE_ATTRIBUTE_LPARAN_RPARAN2                                                = 414, // <Attribute> ::= <Qualified ID> '(' ')'
        RULE_ATTRIBUTE                                                               = 415  // <Attribute> ::= <Qualified ID>
    };

    public class MyParser
    {
        private LALRParser parser;

        public MyParser(string filename)
        {
            FileStream stream = new FileStream(filename,
                                               FileMode.Open, 
                                               FileAccess.Read, 
                                               FileShare.Read);
            Init(stream);
            stream.Close();
        }

        public MyParser(string baseName, string resourceName)
        {
            byte[] buffer = ResourceUtil.GetByteArrayResource(
                System.Reflection.Assembly.GetExecutingAssembly(),
                baseName,
                resourceName);
            MemoryStream stream = new MemoryStream(buffer);
            Init(stream);
            stream.Close();
        }

        public MyParser(Stream stream)
        {
            Init(stream);
        }

        private void Init(Stream stream)
        {
            CGTReader reader = new CGTReader(stream);
            parser = reader.CreateNewParser();
            parser.TrimReductions = false;
            parser.StoreTokens = LALRParser.StoreTokensMode.NoUserObject;

            parser.OnReduce += new LALRParser.ReduceHandler(ReduceEvent);
            parser.OnTokenRead += new LALRParser.TokenReadHandler(TokenReadEvent);
            parser.OnAccept += new LALRParser.AcceptHandler(AcceptEvent);
            parser.OnTokenError += new LALRParser.TokenErrorHandler(TokenErrorEvent);
            parser.OnParseError += new LALRParser.ParseErrorHandler(ParseErrorEvent);
        }

        public void Parse(string source)
        {
            parser.Parse(source);
        }

        private void TokenReadEvent(LALRParser parser, TokenReadEventArgs args)
        {
#if !DEBUG
            try            
#endif
            {
                args.Token.UserObject = CreateObject(args.Token);
            }
#if !DEBUG
            catch (Exception e)
            {
                args.Continue = false;
                //todo: Report message to UI?
            }
#endif
        }

        private Object CreateObject(TerminalToken token)
        {
            switch (token.Symbol.Id)
            {
                case (int)SymbolConstants.SYMBOL_EOF :
                //(EOF)
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_ERROR :
                //(Error)
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_WHITESPACE :
                //(Whitespace)
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_COMMENTEND :
                //(Comment End)
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_COMMENTLINE :
                //(Comment Line)
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_COMMENTSTART :
                //(Comment Start)
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_MINUS :
                //'-'
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_MINUSMINUS :
                //--
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_EXCLAM :
                //'!'
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_EXCLAMEQ :
                //'!='
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_PERCENT :
                //'%'
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_PERCENTEQ :
                //'%='
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_AMP :
                //'&'
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_AMPAMP :
                //'&&'
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_AMPEQ :
                //'&='
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_LPARAN :
                //'('
                //todo: Create a new object that corresponds to the symbol
                Helper.InsideParentheses = true;
                return null;

                case (int)SymbolConstants.SYMBOL_RPARAN :
                //')'
                //todo: Create a new object that corresponds to the symbol
                Helper.InsideParentheses = false;
                return null;

                case (int)SymbolConstants.SYMBOL_TIMES :
                //'*'
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_TIMESEQ :
                //'*='
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_COMMA :
                //','
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_DIV :
                //'/'
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_DIVEQ :
                //'/='
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_COLON :
                //':'
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_SEMI :
                //';'
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_QUESTION :
                //'?'
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_LBRACKET :
                //'['
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_RBRACKET :
                //']'
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_CARET :
                //'^'
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_CARETEQ :
                //'^='
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_LBRACE :
                //'{'
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_PIPE :
                //'|'
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_PIPEPIPE :
                //'||'
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_PIPEEQ :
                //'|='
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_RBRACE :
                //'}'
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_TILDE :
                //'~'
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_PLUS :
                //'+'
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_PLUSPLUS :
                //'++'
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_PLUSEQ :
                //'+='
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_LT :
                //'<'
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_LTLT :
                //'<<'
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_LTLTEQ :
                //'<<='
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_LTEQ :
                //'<='
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_EQ :
                //'='
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_MINUSEQ :
                //'-='
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_EQEQ :
                //'=='
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_GT :
                //'>'
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_MINUSGT :
                //'->'
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_GTEQ :
                //'>='
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_GTGT :
                //'>>'
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_GTGTEQ :
                //'>>='
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_ABSTRACT :
                //abstract
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_ADD :
                //add
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_AS :
                //as
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_ASSEMBLY :
                //assembly
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_BASE :
                //base
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_BOOL :
                //bool
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_BREAK :
                //break
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_BYTE :
                //byte
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_CASE :
                //case
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_CATCH :
                //catch
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_CHAR :
                //char
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_CHARLITERAL :
                //CharLiteral
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_CHECKED :
                //checked
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_CLASS :
                //class
                //todo: Create a new object that corresponds to the symbol
                Helper.addTerminalTokenOnStack(token.Text);
                return null;

                case (int)SymbolConstants.SYMBOL_CONST :
                //const
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_CONTINUE :
                //continue
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_DECIMAL :
                //decimal
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_DECLITERAL :
                //DecLiteral
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_DEFAULT :
                //default
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_DELEGATE :
                //delegate
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_DO :
                //do
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_DOUBLE :
                //double
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_ELSE :
                //else
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_ENUM :
                //enum
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_EVENT :
                //event
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_EXPLICIT :
                //explicit
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_EXTERN :
                //extern
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_FALSE :
                //false
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_FIELD :
                //field
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_FINALLY :
                //finally
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_FIXED :
                //fixed
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_FLOAT :
                //float
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_FOR :
                //for
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_FOREACH :
                //foreach
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_GET :
                //get
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_GOTO :
                //goto
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_HEXLITERAL :
                //HexLiteral
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_IDENTIFIER :
                //Identifier
                //todo: Create a new object that corresponds to the symbol
                Helper.addIdentifier(token.Text);
                return null;

                case (int)SymbolConstants.SYMBOL_IF :
                //if
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_IMPLICIT :
                //implicit
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_IN :
                //in
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_INT :
                //int
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_INTERFACE :
                //interface
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_INTERNAL :
                //internal
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_IS :
                //is
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_LOCK :
                //lock
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_LONG :
                //long
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_MEMBERNAME :
                //MemberName
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_METHOD :
                //method
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_MODULE :
                //module
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_NAMESPACE :
                //namespace
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_NEW :
                //new
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_NULL :
                //null
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_OBJECT :
                //object
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_OPERATOR :
                //operator
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_OUT :
                //out
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_OVERRIDE :
                //override
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_PARAM :
                //param
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_PARAMS :
                //params
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_PARTIAL :
                //partial
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_PRIVATE :
                //private
                //todo: Create a new object that corresponds to the symbol
                Helper.addTerminalTokenOnStack(token.Text);
                return null;

                case (int)SymbolConstants.SYMBOL_PROPERTY :
                //property
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_PROTECTED :
                //protected
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_PUBLIC :
                //public
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_READONLY :
                //readonly
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_REALLITERAL :
                //RealLiteral
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_REF :
                //ref
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_REMOVE :
                //remove
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_RETURN :
                //return
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_SBYTE :
                //sbyte
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_SEALED :
                //sealed
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_SET :
                //set
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_SHORT :
                //short
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_SIZEOF :
                //sizeof
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_STACKALLOC :
                //stackalloc
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_STATIC :
                //static
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_STRING :
                //string
                //todo: Create a new object that corresponds to the symbol
                Helper.addTerminalTokenOnStack(token.Text);
                return null;

                case (int)SymbolConstants.SYMBOL_STRINGLITERAL :
                //StringLiteral
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_STRUCT :
                //struct
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_SWITCH :
                //switch
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_THIS :
                //this
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_THROW :
                //throw
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_TRUE :
                //true
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_TRY :
                //try
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_TYPE :
                //type
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_TYPEOF :
                //typeof
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_UINT :
                //uint
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_ULONG :
                //ulong
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_UNCHECKED :
                //unchecked
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_UNSAFE :
                //unsafe
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_USHORT :
                //ushort
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_USING :
                //using
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_VIRTUAL :
                //virtual
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_VOID :
                //void
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_VOLATILE :
                //volatile
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_WHILE :
                //while
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_ACCESSOPT :
                //<Access Opt>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_ACCESSORDEC :
                //<Accessor Dec>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_ADDEXP :
                //<Add Exp>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_ANDEXP :
                //<And Exp>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_ARGLIST :
                //<Arg List>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_ARGLISTOPT :
                //<Arg List Opt>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_ARGUMENT :
                //<Argument>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_ARRAYINITIALIZER :
                //<Array Initializer>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_ARRAYINITIALIZEROPT :
                //<Array Initializer Opt>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_ASSIGNTAIL :
                //<Assign Tail>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_ATTRIBLIST :
                //<Attrib List>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_ATTRIBOPT :
                //<Attrib Opt>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_ATTRIBSECTION :
                //<Attrib Section>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_ATTRIBTARGETSPECOPT :
                //<Attrib Target Spec Opt>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_ATTRIBUTE :
                //<Attribute>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_BASETYPE :
                //<Base Type>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_BLOCK :
                //<Block>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_BLOCKORSEMI :
                //<Block or Semi>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_CATCHCLAUSE :
                //<Catch Clause>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_CATCHCLAUSES :
                //<Catch Clauses>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_CLASSBASELIST :
                //<Class Base List>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_CLASSBASEOPT :
                //<Class Base Opt>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_CLASSDECL :
                //<Class Decl>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_CLASSITEM :
                //<Class Item>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_CLASSITEMDECSOPT :
                //<Class Item Decs Opt>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_COMPAREEXP :
                //<Compare Exp>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_COMPILATIONITEM :
                //<Compilation Item>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_COMPILATIONITEMS :
                //<Compilation Items>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_COMPILATIONUNIT :
                //<Compilation Unit>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_CONDITIONALEXP :
                //<Conditional Exp>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_CONSTANTDEC :
                //<Constant Dec>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_CONSTANTDECLARATOR :
                //<Constant Declarator>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_CONSTANTDECLARATORS :
                //<Constant Declarators>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_CONSTRUCTORDEC :
                //<Constructor Dec>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_CONSTRUCTORDECLARATOR :
                //<Constructor Declarator>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_CONSTRUCTORINIT :
                //<Constructor Init>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_CONSTRUCTORINITOPT :
                //<Constructor Init Opt>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_CONVERSIONOPERATORDECL :
                //<Conversion Operator Decl>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_DELEGATEDECL :
                //<Delegate Decl>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_DESTRUCTORDEC :
                //<Destructor Dec>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_DIMSEPARATORS :
                //<Dim Separators>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_ENUMBASEOPT :
                //<Enum Base Opt>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_ENUMBODY :
                //<Enum Body>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_ENUMDECL :
                //<Enum Decl>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_ENUMITEMDEC :
                //<Enum Item Dec>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_ENUMITEMDECS :
                //<Enum Item Decs>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_ENUMITEMDECSOPT :
                //<Enum Item Decs Opt>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_EQUALITYEXP :
                //<Equality Exp>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_EVENTACCESSORDECS :
                //<Event Accessor Decs>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_EVENTDEC :
                //<Event Dec>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_EXPRESSION :
                //<Expression>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_EXPRESSIONLIST :
                //<Expression List>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_EXPRESSIONOPT :
                //<Expression Opt>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_FIELDDEC :
                //<Field Dec>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_FINALLYCLAUSEOPT :
                //<Finally Clause Opt>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_FIXEDPTRDEC :
                //<Fixed Ptr Dec>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_FIXEDPTRDECS :
                //<Fixed Ptr Decs>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_FORCONDITIONOPT :
                //<For Condition Opt>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_FORINITOPT :
                //<For Init Opt>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_FORITERATOROPT :
                //<For Iterator Opt>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_FORMALPARAM :
                //<Formal Param>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_FORMALPARAMLIST :
                //<Formal Param List>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_FORMALPARAMLISTOPT :
                //<Formal Param List Opt>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_HEADER :
                //<Header>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_INDEXERDEC :
                //<Indexer Dec>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_INTEGRALTYPE :
                //<Integral Type>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_INTERFACEACCESSORS :
                //<Interface Accessors>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_INTERFACEBASEOPT :
                //<Interface Base Opt>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_INTERFACEDECL :
                //<Interface Decl>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_INTERFACEEMPTYBODY :
                //<Interface Empty Body>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_INTERFACEEVENTDEC :
                //<Interface Event Dec>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_INTERFACEINDEXERDEC :
                //<Interface Indexer Dec>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_INTERFACEITEMDEC :
                //<Interface Item Dec>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_INTERFACEITEMDECSOPT :
                //<Interface Item Decs Opt>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_INTERFACEMETHODDEC :
                //<Interface Method Dec>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_INTERFACEPROPERTYDEC :
                //<Interface Property Dec>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_LITERAL :
                //<Literal>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_LOCALVARDECL :
                //<Local Var Decl>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_LOGICALANDEXP :
                //<Logical And Exp>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_LOGICALOREXP :
                //<Logical Or Exp>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_LOGICALXOREXP :
                //<Logical Xor Exp>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_MEMBERLIST :
                //<Member List>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_METHOD2 :
                //<Method>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_METHODDEC :
                //<Method Dec>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_METHODEXP :
                //<Method Exp>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_METHODSOPT :
                //<Methods Opt>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_MODIFIER :
                //<Modifier>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_MODIFIERLISTOPT :
                //<Modifier List Opt>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_MULTEXP :
                //<Mult Exp>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_NAMESPACEDEC :
                //<Namespace Dec>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_NAMESPACEITEM :
                //<Namespace Item>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_NAMESPACEITEMS :
                //<Namespace Items>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_NEWOPT :
                //<New Opt>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_NONARRAYTYPE :
                //<Non Array Type>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_NORMALSTM :
                //<Normal Stm>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_OBJECTEXP :
                //<Object Exp>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_OPERATORDEC :
                //<Operator Dec>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_OREXP :
                //<Or Exp>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_OTHERTYPE :
                //<Other Type>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_OVERLOADOP :
                //<Overload Op>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_OVERLOADOPERATORDECL :
                //<Overload Operator Decl>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_POINTEROPT :
                //<Pointer Opt>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_PRIMARY :
                //<Primary>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_PRIMARYARRAYCREATIONEXP :
                //<Primary Array Creation Exp>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_PRIMARYEXP :
                //<Primary Exp>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_PROPERTYDEC :
                //<Property Dec>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_QUALIFIEDID :
                //<Qualified ID>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_RANKSPECIFIER :
                //<Rank Specifier>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_RANKSPECIFIERS :
                //<Rank Specifiers>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_RANKSPECIFIERSOPT :
                //<Rank Specifiers Opt>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_RESOURCE :
                //<Resource>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_SEMICOLONOPT :
                //<Semicolon Opt>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_SHIFTEXP :
                //<Shift Exp>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_STATEMENT :
                //<Statement>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_STATEMENTEXP :
                //<Statement Exp>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_STATEMENTEXPLIST :
                //<Statement Exp List>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_STMLIST :
                //<Stm List>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_STRUCTDECL :
                //<Struct Decl>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_SWITCHLABEL :
                //<Switch Label>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_SWITCHLABELS :
                //<Switch Labels>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_SWITCHSECTION :
                //<Switch Section>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_SWITCHSECTIONSOPT :
                //<Switch Sections Opt>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_THENSTM :
                //<Then Stm>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_TYPE2 :
                //<Type>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_TYPEDECL :
                //<Type Decl>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_UNARYEXP :
                //<Unary Exp>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_USINGDIRECTIVE :
                //<Using Directive>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_USINGLIST :
                //<Using List>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_VALIDID :
                //<Valid ID>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_VARIABLEDECLARATOR :
                //<Variable Declarator>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_VARIABLEDECS :
                //<Variable Decs>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_VARIABLEINITIALIZER :
                //<Variable Initializer>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_VARIABLEINITIALIZERLIST :
                //<Variable Initializer List>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_VARIABLEINITIALIZERLISTOPT :
                //<Variable Initializer List Opt>
                //todo: Create a new object that corresponds to the symbol
                return null;

            }
            throw new SymbolException("Unknown symbol");
        }

        private void ReduceEvent(LALRParser parser, ReduceEventArgs args)
        {
#if !DEBUG
            try
#endif
            {
                args.Token.UserObject = CreateObject(args.Token);
            }
#if !DEBUG
            catch (Exception e)
            {
                args.Continue = false;
                //todo: Report message to UI?
            }
#endif
        }

        public static Object CreateObject(NonterminalToken token)
        {
            switch (token.Rule.Id)
            {
                case (int)RuleConstants.RULE_BLOCKORSEMI :
                //<Block or Semi> ::= <Block>
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_BLOCKORSEMI_SEMI :
                //<Block or Semi> ::= ';'
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_VALIDID_IDENTIFIER :
                //<Valid ID> ::= Identifier
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_VALIDID_THIS :
                //<Valid ID> ::= this
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_VALIDID_BASE :
                //<Valid ID> ::= base
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_VALIDID :
                //<Valid ID> ::= <Base Type>
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_QUALIFIEDID :
                //<Qualified ID> ::= <Valid ID> <Member List>
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_MEMBERLIST_MEMBERNAME :
                //<Member List> ::= <Member List> MemberName
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_MEMBERLIST :
                //<Member List> ::= 
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_SEMICOLONOPT_SEMI :
                //<Semicolon Opt> ::= ';'
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_SEMICOLONOPT :
                //<Semicolon Opt> ::= 
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_LITERAL_TRUE :
                //<Literal> ::= true
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_LITERAL_FALSE :
                //<Literal> ::= false
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_LITERAL_DECLITERAL :
                //<Literal> ::= DecLiteral
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_LITERAL_HEXLITERAL :
                //<Literal> ::= HexLiteral
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_LITERAL_REALLITERAL :
                //<Literal> ::= RealLiteral
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_LITERAL_CHARLITERAL :
                //<Literal> ::= CharLiteral
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_LITERAL_STRINGLITERAL :
                //<Literal> ::= StringLiteral
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_LITERAL_NULL :
                //<Literal> ::= null
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_TYPE :
                //<Type> ::= <Non Array Type>
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_TYPE_TIMES :
                //<Type> ::= <Non Array Type> '*'
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_TYPE2 :
                //<Type> ::= <Non Array Type> <Rank Specifiers>
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_TYPE_TIMES2 :
                //<Type> ::= <Non Array Type> <Rank Specifiers> '*'
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_POINTEROPT_TIMES :
                //<Pointer Opt> ::= '*'
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_POINTEROPT :
                //<Pointer Opt> ::= 
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_NONARRAYTYPE :
                //<Non Array Type> ::= <Qualified ID>
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_BASETYPE :
                //<Base Type> ::= <Other Type>
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_BASETYPE2 :
                //<Base Type> ::= <Integral Type>
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_OTHERTYPE_FLOAT :
                //<Other Type> ::= float
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_OTHERTYPE_DOUBLE :
                //<Other Type> ::= double
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_OTHERTYPE_DECIMAL :
                //<Other Type> ::= decimal
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_OTHERTYPE_BOOL :
                //<Other Type> ::= bool
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_OTHERTYPE_VOID :
                //<Other Type> ::= void
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_OTHERTYPE_OBJECT :
                //<Other Type> ::= object
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_OTHERTYPE_STRING :
                //<Other Type> ::= string
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_INTEGRALTYPE_SBYTE :
                //<Integral Type> ::= sbyte
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_INTEGRALTYPE_BYTE :
                //<Integral Type> ::= byte
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_INTEGRALTYPE_SHORT :
                //<Integral Type> ::= short
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_INTEGRALTYPE_USHORT :
                //<Integral Type> ::= ushort
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_INTEGRALTYPE_INT :
                //<Integral Type> ::= int
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_INTEGRALTYPE_UINT :
                //<Integral Type> ::= uint
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_INTEGRALTYPE_LONG :
                //<Integral Type> ::= long
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_INTEGRALTYPE_ULONG :
                //<Integral Type> ::= ulong
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_INTEGRALTYPE_CHAR :
                //<Integral Type> ::= char
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_RANKSPECIFIERSOPT :
                //<Rank Specifiers Opt> ::= <Rank Specifiers Opt> <Rank Specifier>
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_RANKSPECIFIERSOPT2 :
                //<Rank Specifiers Opt> ::= 
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_RANKSPECIFIERS :
                //<Rank Specifiers> ::= <Rank Specifiers> <Rank Specifier>
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_RANKSPECIFIERS2 :
                //<Rank Specifiers> ::= <Rank Specifier>
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_RANKSPECIFIER_LBRACKET_RBRACKET :
                //<Rank Specifier> ::= '[' <Dim Separators> ']'
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_DIMSEPARATORS_COMMA :
                //<Dim Separators> ::= <Dim Separators> ','
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_DIMSEPARATORS :
                //<Dim Separators> ::= 
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_EXPRESSIONOPT :
                //<Expression Opt> ::= <Expression>
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_EXPRESSIONOPT2 :
                //<Expression Opt> ::= 
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_EXPRESSIONLIST :
                //<Expression List> ::= <Expression>
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_EXPRESSIONLIST_COMMA :
                //<Expression List> ::= <Expression> ',' <Expression List>
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_EXPRESSION_EQ :
                //<Expression> ::= <Conditional Exp> '=' <Expression>
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_EXPRESSION_PLUSEQ :
                //<Expression> ::= <Conditional Exp> '+=' <Expression>
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_EXPRESSION_MINUSEQ :
                //<Expression> ::= <Conditional Exp> '-=' <Expression>
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_EXPRESSION_TIMESEQ :
                //<Expression> ::= <Conditional Exp> '*=' <Expression>
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_EXPRESSION_DIVEQ :
                //<Expression> ::= <Conditional Exp> '/=' <Expression>
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_EXPRESSION_CARETEQ :
                //<Expression> ::= <Conditional Exp> '^=' <Expression>
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_EXPRESSION_AMPEQ :
                //<Expression> ::= <Conditional Exp> '&=' <Expression>
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_EXPRESSION_PIPEEQ :
                //<Expression> ::= <Conditional Exp> '|=' <Expression>
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_EXPRESSION_PERCENTEQ :
                //<Expression> ::= <Conditional Exp> '%=' <Expression>
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_EXPRESSION_LTLTEQ :
                //<Expression> ::= <Conditional Exp> '<<=' <Expression>
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_EXPRESSION_GTGTEQ :
                //<Expression> ::= <Conditional Exp> '>>=' <Expression>
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_EXPRESSION :
                //<Expression> ::= <Conditional Exp>
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_CONDITIONALEXP_QUESTION_COLON :
                //<Conditional Exp> ::= <Or Exp> '?' <Or Exp> ':' <Conditional Exp>
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_CONDITIONALEXP :
                //<Conditional Exp> ::= <Or Exp>
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_OREXP_PIPEPIPE :
                //<Or Exp> ::= <Or Exp> '||' <And Exp>
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_OREXP :
                //<Or Exp> ::= <And Exp>
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_ANDEXP_AMPAMP :
                //<And Exp> ::= <And Exp> '&&' <Logical Or Exp>
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_ANDEXP :
                //<And Exp> ::= <Logical Or Exp>
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_LOGICALOREXP_PIPE :
                //<Logical Or Exp> ::= <Logical Or Exp> '|' <Logical Xor Exp>
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_LOGICALOREXP :
                //<Logical Or Exp> ::= <Logical Xor Exp>
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_LOGICALXOREXP_CARET :
                //<Logical Xor Exp> ::= <Logical Xor Exp> '^' <Logical And Exp>
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_LOGICALXOREXP :
                //<Logical Xor Exp> ::= <Logical And Exp>
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_LOGICALANDEXP_AMP :
                //<Logical And Exp> ::= <Logical And Exp> '&' <Equality Exp>
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_LOGICALANDEXP :
                //<Logical And Exp> ::= <Equality Exp>
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_EQUALITYEXP_EQEQ :
                //<Equality Exp> ::= <Equality Exp> '==' <Compare Exp>
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_EQUALITYEXP_EXCLAMEQ :
                //<Equality Exp> ::= <Equality Exp> '!=' <Compare Exp>
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_EQUALITYEXP :
                //<Equality Exp> ::= <Compare Exp>
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_COMPAREEXP_LT :
                //<Compare Exp> ::= <Compare Exp> '<' <Shift Exp>
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_COMPAREEXP_GT :
                //<Compare Exp> ::= <Compare Exp> '>' <Shift Exp>
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_COMPAREEXP_LTEQ :
                //<Compare Exp> ::= <Compare Exp> '<=' <Shift Exp>
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_COMPAREEXP_GTEQ :
                //<Compare Exp> ::= <Compare Exp> '>=' <Shift Exp>
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_COMPAREEXP_IS :
                //<Compare Exp> ::= <Compare Exp> is <Type>
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_COMPAREEXP_AS :
                //<Compare Exp> ::= <Compare Exp> as <Type>
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_COMPAREEXP :
                //<Compare Exp> ::= <Shift Exp>
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_SHIFTEXP_LTLT :
                //<Shift Exp> ::= <Shift Exp> '<<' <Add Exp>
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_SHIFTEXP_GTGT :
                //<Shift Exp> ::= <Shift Exp> '>>' <Add Exp>
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_SHIFTEXP :
                //<Shift Exp> ::= <Add Exp>
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_ADDEXP_PLUS :
                //<Add Exp> ::= <Add Exp> '+' <Mult Exp>
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_ADDEXP_MINUS :
                //<Add Exp> ::= <Add Exp> '-' <Mult Exp>
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_ADDEXP :
                //<Add Exp> ::= <Mult Exp>
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_MULTEXP_TIMES :
                //<Mult Exp> ::= <Mult Exp> '*' <Unary Exp>
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_MULTEXP_DIV :
                //<Mult Exp> ::= <Mult Exp> '/' <Unary Exp>
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_MULTEXP_PERCENT :
                //<Mult Exp> ::= <Mult Exp> '%' <Unary Exp>
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_MULTEXP :
                //<Mult Exp> ::= <Unary Exp>
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_UNARYEXP_EXCLAM :
                //<Unary Exp> ::= '!' <Unary Exp>
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_UNARYEXP_TILDE :
                //<Unary Exp> ::= '~' <Unary Exp>
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_UNARYEXP_MINUS :
                //<Unary Exp> ::= '-' <Unary Exp>
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_UNARYEXP_PLUSPLUS :
                //<Unary Exp> ::= '++' <Unary Exp>
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_UNARYEXP_MINUSMINUS :
                //<Unary Exp> ::= -- <Unary Exp>
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_UNARYEXP_LPARAN_RPARAN :
                //<Unary Exp> ::= '(' <Expression> ')' <Object Exp>
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_UNARYEXP :
                //<Unary Exp> ::= <Object Exp>
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_OBJECTEXP_DELEGATE_LPARAN_RPARAN :
                //<Object Exp> ::= delegate '(' <Formal Param List Opt> ')' <Block>
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_OBJECTEXP :
                //<Object Exp> ::= <Primary Array Creation Exp>
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_OBJECTEXP2 :
                //<Object Exp> ::= <Method Exp>
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_PRIMARYARRAYCREATIONEXP_NEW_LBRACKET_RBRACKET :
                //<Primary Array Creation Exp> ::= new <Non Array Type> '[' <Expression List> ']' <Rank Specifiers Opt> <Array Initializer Opt>
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_PRIMARYARRAYCREATIONEXP_NEW :
                //<Primary Array Creation Exp> ::= new <Non Array Type> <Rank Specifiers> <Array Initializer>
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_METHODEXP :
                //<Method Exp> ::= <Method Exp> <Method>
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_METHODEXP2 :
                //<Method Exp> ::= <Primary Exp>
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_PRIMARYEXP_TYPEOF_LPARAN_RPARAN :
                //<Primary Exp> ::= typeof '(' <Type> ')'
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_PRIMARYEXP_SIZEOF_LPARAN_RPARAN :
                //<Primary Exp> ::= sizeof '(' <Type> ')'
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_PRIMARYEXP_CHECKED_LPARAN_RPARAN :
                //<Primary Exp> ::= checked '(' <Expression> ')'
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_PRIMARYEXP_UNCHECKED_LPARAN_RPARAN :
                //<Primary Exp> ::= unchecked '(' <Expression> ')'
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_PRIMARYEXP_NEW_LPARAN_RPARAN :
                //<Primary Exp> ::= new <Non Array Type> '(' <Arg List Opt> ')'
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_PRIMARYEXP :
                //<Primary Exp> ::= <Primary>
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_PRIMARYEXP_LPARAN_RPARAN :
                //<Primary Exp> ::= '(' <Expression> ')'
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_PRIMARY :
                //<Primary> ::= <Valid ID>
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_PRIMARY_LPARAN_RPARAN :
                //<Primary> ::= <Valid ID> '(' <Arg List Opt> ')'
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_PRIMARY2 :
                //<Primary> ::= <Literal>
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_ARGLISTOPT :
                //<Arg List Opt> ::= <Arg List>
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_ARGLISTOPT2 :
                //<Arg List Opt> ::= 
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_ARGLIST_COMMA :
                //<Arg List> ::= <Arg List> ',' <Argument>
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_ARGLIST :
                //<Arg List> ::= <Argument>
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_ARGUMENT :
                //<Argument> ::= <Expression>
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_ARGUMENT_REF :
                //<Argument> ::= ref <Expression>
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_ARGUMENT_OUT :
                //<Argument> ::= out <Expression>
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_STMLIST :
                //<Stm List> ::= <Stm List> <Statement>
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_STMLIST2 :
                //<Stm List> ::= <Statement>
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_STATEMENT_IDENTIFIER_COLON :
                //<Statement> ::= Identifier ':'
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_STATEMENT_SEMI :
                //<Statement> ::= <Local Var Decl> ';'
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_STATEMENT_IF_LPARAN_RPARAN :
                //<Statement> ::= if '(' <Expression> ')' <Statement>
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_STATEMENT_IF_LPARAN_RPARAN_ELSE :
                //<Statement> ::= if '(' <Expression> ')' <Then Stm> else <Statement>
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_STATEMENT_FOR_LPARAN_SEMI_SEMI_RPARAN :
                //<Statement> ::= for '(' <For Init Opt> ';' <For Condition Opt> ';' <For Iterator Opt> ')' <Statement>
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_STATEMENT_FOREACH_LPARAN_IDENTIFIER_IN_RPARAN :
                //<Statement> ::= foreach '(' <Type> Identifier in <Expression> ')' <Statement>
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_STATEMENT_WHILE_LPARAN_RPARAN :
                //<Statement> ::= while '(' <Expression> ')' <Statement>
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_STATEMENT_LOCK_LPARAN_RPARAN :
                //<Statement> ::= lock '(' <Expression> ')' <Statement>
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_STATEMENT_USING_LPARAN_RPARAN :
                //<Statement> ::= using '(' <Resource> ')' <Statement>
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_STATEMENT_FIXED_LPARAN_RPARAN :
                //<Statement> ::= fixed '(' <Type> <Fixed Ptr Decs> ')' <Statement>
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_STATEMENT_DELEGATE_LPARAN_RPARAN :
                //<Statement> ::= delegate '(' <Formal Param List Opt> ')' <Statement>
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_STATEMENT :
                //<Statement> ::= <Normal Stm>
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_THENSTM_IF_LPARAN_RPARAN_ELSE :
                //<Then Stm> ::= if '(' <Expression> ')' <Then Stm> else <Then Stm>
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_THENSTM_FOR_LPARAN_SEMI_SEMI_RPARAN :
                //<Then Stm> ::= for '(' <For Init Opt> ';' <For Condition Opt> ';' <For Iterator Opt> ')' <Then Stm>
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_THENSTM_FOREACH_LPARAN_IDENTIFIER_IN_RPARAN :
                //<Then Stm> ::= foreach '(' <Type> Identifier in <Expression> ')' <Then Stm>
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_THENSTM_WHILE_LPARAN_RPARAN :
                //<Then Stm> ::= while '(' <Expression> ')' <Then Stm>
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_THENSTM_LOCK_LPARAN_RPARAN :
                //<Then Stm> ::= lock '(' <Expression> ')' <Then Stm>
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_THENSTM_USING_LPARAN_RPARAN :
                //<Then Stm> ::= using '(' <Resource> ')' <Then Stm>
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_THENSTM_FIXED_LPARAN_RPARAN :
                //<Then Stm> ::= fixed '(' <Type> <Fixed Ptr Decs> ')' <Then Stm>
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_THENSTM_DELEGATE_LPARAN_RPARAN :
                //<Then Stm> ::= delegate '(' <Formal Param List Opt> ')' <Then Stm>
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_THENSTM :
                //<Then Stm> ::= <Normal Stm>
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_NORMALSTM_SWITCH_LPARAN_RPARAN_LBRACE_RBRACE :
                //<Normal Stm> ::= switch '(' <Expression> ')' '{' <Switch Sections Opt> '}'
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_NORMALSTM_DO_WHILE_LPARAN_RPARAN_SEMI :
                //<Normal Stm> ::= do <Normal Stm> while '(' <Expression> ')' ';'
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_NORMALSTM_TRY :
                //<Normal Stm> ::= try <Block> <Catch Clauses> <Finally Clause Opt>
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_NORMALSTM_CHECKED :
                //<Normal Stm> ::= checked <Block>
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_NORMALSTM_UNCHECKED :
                //<Normal Stm> ::= unchecked <Block>
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_NORMALSTM_UNSAFE :
                //<Normal Stm> ::= unsafe <Block>
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_NORMALSTM_BREAK_SEMI :
                //<Normal Stm> ::= break ';'
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_NORMALSTM_CONTINUE_SEMI :
                //<Normal Stm> ::= continue ';'
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_NORMALSTM_GOTO_IDENTIFIER_SEMI :
                //<Normal Stm> ::= goto Identifier ';'
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_NORMALSTM_GOTO_CASE_SEMI :
                //<Normal Stm> ::= goto case <Expression> ';'
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_NORMALSTM_GOTO_DEFAULT_SEMI :
                //<Normal Stm> ::= goto default ';'
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_NORMALSTM_RETURN_SEMI :
                //<Normal Stm> ::= return <Expression Opt> ';'
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_NORMALSTM_THROW_SEMI :
                //<Normal Stm> ::= throw <Expression Opt> ';'
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_NORMALSTM_SEMI :
                //<Normal Stm> ::= <Statement Exp> ';'
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_NORMALSTM_SEMI2 :
                //<Normal Stm> ::= ';'
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_NORMALSTM :
                //<Normal Stm> ::= <Block>
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_BLOCK_LBRACE_RBRACE :
                //<Block> ::= '{' <Stm List> '}'
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_BLOCK_LBRACE_RBRACE2 :
                //<Block> ::= '{' '}'
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_VARIABLEDECS :
                //<Variable Decs> ::= <Variable Declarator>
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_VARIABLEDECS_COMMA :
                //<Variable Decs> ::= <Variable Decs> ',' <Variable Declarator>
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_VARIABLEDECLARATOR_IDENTIFIER :
                //<Variable Declarator> ::= Identifier
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_VARIABLEDECLARATOR_IDENTIFIER_EQ :
                //<Variable Declarator> ::= Identifier '=' <Variable Initializer>
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_VARIABLEINITIALIZER :
                //<Variable Initializer> ::= <Expression>
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_VARIABLEINITIALIZER2 :
                //<Variable Initializer> ::= <Array Initializer>
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_VARIABLEINITIALIZER_STACKALLOC_LBRACKET_RBRACKET :
                //<Variable Initializer> ::= stackalloc <Non Array Type> '[' <Non Array Type> ']'
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_CONSTANTDECLARATORS :
                //<Constant Declarators> ::= <Constant Declarator>
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_CONSTANTDECLARATORS_COMMA :
                //<Constant Declarators> ::= <Constant Declarators> ',' <Constant Declarator>
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_CONSTANTDECLARATOR_IDENTIFIER_EQ :
                //<Constant Declarator> ::= Identifier '=' <Expression>
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_SWITCHSECTIONSOPT :
                //<Switch Sections Opt> ::= <Switch Sections Opt> <Switch Section>
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_SWITCHSECTIONSOPT2 :
                //<Switch Sections Opt> ::= 
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_SWITCHSECTION :
                //<Switch Section> ::= <Switch Labels> <Stm List>
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_SWITCHLABELS :
                //<Switch Labels> ::= <Switch Label>
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_SWITCHLABELS2 :
                //<Switch Labels> ::= <Switch Labels> <Switch Label>
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_SWITCHLABEL_CASE_COLON :
                //<Switch Label> ::= case <Expression> ':'
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_SWITCHLABEL_DEFAULT_COLON :
                //<Switch Label> ::= default ':'
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_FORINITOPT :
                //<For Init Opt> ::= <Local Var Decl>
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_FORINITOPT2 :
                //<For Init Opt> ::= <Statement Exp List>
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_FORINITOPT3 :
                //<For Init Opt> ::= 
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_FORITERATOROPT :
                //<For Iterator Opt> ::= <Statement Exp List>
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_FORITERATOROPT2 :
                //<For Iterator Opt> ::= 
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_FORCONDITIONOPT :
                //<For Condition Opt> ::= <Expression>
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_FORCONDITIONOPT2 :
                //<For Condition Opt> ::= 
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_STATEMENTEXPLIST_COMMA :
                //<Statement Exp List> ::= <Statement Exp List> ',' <Statement Exp>
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_STATEMENTEXPLIST :
                //<Statement Exp List> ::= <Statement Exp>
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_CATCHCLAUSES :
                //<Catch Clauses> ::= <Catch Clause> <Catch Clauses>
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_CATCHCLAUSES2 :
                //<Catch Clauses> ::= 
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_CATCHCLAUSE_CATCH_LPARAN_IDENTIFIER_RPARAN :
                //<Catch Clause> ::= catch '(' <Qualified ID> Identifier ')' <Block>
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_CATCHCLAUSE_CATCH_LPARAN_RPARAN :
                //<Catch Clause> ::= catch '(' <Qualified ID> ')' <Block>
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_CATCHCLAUSE_CATCH :
                //<Catch Clause> ::= catch <Block>
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_FINALLYCLAUSEOPT_FINALLY :
                //<Finally Clause Opt> ::= finally <Block>
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_FINALLYCLAUSEOPT :
                //<Finally Clause Opt> ::= 
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_RESOURCE :
                //<Resource> ::= <Local Var Decl>
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_RESOURCE2 :
                //<Resource> ::= <Statement Exp>
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_FIXEDPTRDECS :
                //<Fixed Ptr Decs> ::= <Fixed Ptr Dec>
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_FIXEDPTRDECS_COMMA :
                //<Fixed Ptr Decs> ::= <Fixed Ptr Decs> ',' <Fixed Ptr Dec>
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_FIXEDPTRDEC_IDENTIFIER_EQ :
                //<Fixed Ptr Dec> ::= Identifier '=' <Expression>
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_LOCALVARDECL :
                //<Local Var Decl> ::= <Qualified ID> <Rank Specifiers> <Pointer Opt> <Variable Decs>
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_LOCALVARDECL2 :
                //<Local Var Decl> ::= <Qualified ID> <Pointer Opt> <Variable Decs>
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_STATEMENTEXP_LPARAN_RPARAN :
                //<Statement Exp> ::= <Qualified ID> '(' <Arg List Opt> ')'
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_STATEMENTEXP_LPARAN_RPARAN2 :
                //<Statement Exp> ::= <Qualified ID> '(' <Arg List Opt> ')' <Methods Opt> <Assign Tail>
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_STATEMENTEXP_LBRACKET_RBRACKET :
                //<Statement Exp> ::= <Qualified ID> '[' <Expression List> ']' <Methods Opt> <Assign Tail>
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_STATEMENTEXP_MINUSGT_IDENTIFIER :
                //<Statement Exp> ::= <Qualified ID> '->' Identifier <Methods Opt> <Assign Tail>
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_STATEMENTEXP_PLUSPLUS :
                //<Statement Exp> ::= <Qualified ID> '++' <Methods Opt> <Assign Tail>
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_STATEMENTEXP_MINUSMINUS :
                //<Statement Exp> ::= <Qualified ID> -- <Methods Opt> <Assign Tail>
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_STATEMENTEXP :
                //<Statement Exp> ::= <Qualified ID> <Assign Tail>
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_ASSIGNTAIL_PLUSPLUS :
                //<Assign Tail> ::= '++'
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_ASSIGNTAIL_MINUSMINUS :
                //<Assign Tail> ::= --
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_ASSIGNTAIL_EQ :
                //<Assign Tail> ::= '=' <Expression>
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_ASSIGNTAIL_PLUSEQ :
                //<Assign Tail> ::= '+=' <Expression>
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_ASSIGNTAIL_MINUSEQ :
                //<Assign Tail> ::= '-=' <Expression>
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_ASSIGNTAIL_TIMESEQ :
                //<Assign Tail> ::= '*=' <Expression>
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_ASSIGNTAIL_DIVEQ :
                //<Assign Tail> ::= '/=' <Expression>
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_ASSIGNTAIL_CARETEQ :
                //<Assign Tail> ::= '^=' <Expression>
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_ASSIGNTAIL_AMPEQ :
                //<Assign Tail> ::= '&=' <Expression>
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_ASSIGNTAIL_PIPEEQ :
                //<Assign Tail> ::= '|=' <Expression>
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_ASSIGNTAIL_PERCENTEQ :
                //<Assign Tail> ::= '%=' <Expression>
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_ASSIGNTAIL_LTLTEQ :
                //<Assign Tail> ::= '<<=' <Expression>
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_ASSIGNTAIL_GTGTEQ :
                //<Assign Tail> ::= '>>=' <Expression>
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_METHODSOPT :
                //<Methods Opt> ::= <Methods Opt> <Method>
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_METHODSOPT2 :
                //<Methods Opt> ::= 
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_METHOD_MEMBERNAME :
                //<Method> ::= MemberName
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_METHOD_MEMBERNAME_LPARAN_RPARAN :
                //<Method> ::= MemberName '(' <Arg List Opt> ')'
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_METHOD_LBRACKET_RBRACKET :
                //<Method> ::= '[' <Expression List> ']'
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_METHOD_MINUSGT_IDENTIFIER :
                //<Method> ::= '->' Identifier
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_METHOD_PLUSPLUS :
                //<Method> ::= '++'
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_METHOD_MINUSMINUS :
                //<Method> ::= --
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_COMPILATIONUNIT :
                //<Compilation Unit> ::= <Using List> <Compilation Items>
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_USINGLIST :
                //<Using List> ::= <Using List> <Using Directive>
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_USINGLIST2 :
                //<Using List> ::= 
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_USINGDIRECTIVE_USING_IDENTIFIER_EQ_SEMI :
                //<Using Directive> ::= using Identifier '=' <Qualified ID> ';'
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_USINGDIRECTIVE_USING_SEMI :
                //<Using Directive> ::= using <Qualified ID> ';'
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_COMPILATIONITEMS :
                //<Compilation Items> ::= <Compilation Items> <Compilation Item>
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_COMPILATIONITEMS2 :
                //<Compilation Items> ::= 
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_COMPILATIONITEM :
                //<Compilation Item> ::= <Namespace Dec>
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_COMPILATIONITEM2 :
                //<Compilation Item> ::= <Namespace Item>
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_NAMESPACEDEC_NAMESPACE_LBRACE_RBRACE :
                //<Namespace Dec> ::= <Attrib Opt> namespace <Qualified ID> '{' <Using List> <Namespace Items> '}' <Semicolon Opt>
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_NAMESPACEITEMS :
                //<Namespace Items> ::= <Namespace Items> <Namespace Item>
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_NAMESPACEITEMS2 :
                //<Namespace Items> ::= 
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_NAMESPACEITEM :
                //<Namespace Item> ::= <Constant Dec>
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_NAMESPACEITEM2 :
                //<Namespace Item> ::= <Field Dec>
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_NAMESPACEITEM3 :
                //<Namespace Item> ::= <Method Dec>
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_NAMESPACEITEM4 :
                //<Namespace Item> ::= <Property Dec>
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_NAMESPACEITEM5 :
                //<Namespace Item> ::= <Type Decl>
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_TYPEDECL :
                //<Type Decl> ::= <Class Decl>
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_TYPEDECL2 :
                //<Type Decl> ::= <Struct Decl>
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_TYPEDECL3 :
                //<Type Decl> ::= <Interface Decl>
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_TYPEDECL4 :
                //<Type Decl> ::= <Enum Decl>
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_TYPEDECL5 :
                //<Type Decl> ::= <Delegate Decl>
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_HEADER :
                //<Header> ::= <Attrib Opt> <Access Opt> <Modifier List Opt>
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_ACCESSOPT_PRIVATE :
                //<Access Opt> ::= private
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_ACCESSOPT_PROTECTED :
                //<Access Opt> ::= protected
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_ACCESSOPT_PUBLIC :
                //<Access Opt> ::= public
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_ACCESSOPT_INTERNAL :
                //<Access Opt> ::= internal
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_ACCESSOPT :
                //<Access Opt> ::= 
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_MODIFIERLISTOPT :
                //<Modifier List Opt> ::= <Modifier List Opt> <Modifier>
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_MODIFIERLISTOPT2 :
                //<Modifier List Opt> ::= 
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_MODIFIER_ABSTRACT :
                //<Modifier> ::= abstract
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_MODIFIER_EXTERN :
                //<Modifier> ::= extern
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_MODIFIER_NEW :
                //<Modifier> ::= new
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_MODIFIER_OVERRIDE :
                //<Modifier> ::= override
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_MODIFIER_PARTIAL :
                //<Modifier> ::= partial
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_MODIFIER_READONLY :
                //<Modifier> ::= readonly
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_MODIFIER_SEALED :
                //<Modifier> ::= sealed
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_MODIFIER_STATIC :
                //<Modifier> ::= static
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_MODIFIER_UNSAFE :
                //<Modifier> ::= unsafe
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_MODIFIER_VIRTUAL :
                //<Modifier> ::= virtual
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_MODIFIER_VOLATILE :
                //<Modifier> ::= volatile
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_CLASSDECL_CLASS_IDENTIFIER_LBRACE_RBRACE :
                //<Class Decl> ::= <Header> class Identifier <Class Base Opt> '{' <Class Item Decs Opt> '}' <Semicolon Opt>
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_CLASSBASEOPT_COLON :
                //<Class Base Opt> ::= ':' <Class Base List>
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_CLASSBASEOPT :
                //<Class Base Opt> ::= 
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_CLASSBASELIST_COMMA :
                //<Class Base List> ::= <Class Base List> ',' <Non Array Type>
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_CLASSBASELIST :
                //<Class Base List> ::= <Non Array Type>
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_CLASSITEMDECSOPT :
                //<Class Item Decs Opt> ::= <Class Item Decs Opt> <Class Item>
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_CLASSITEMDECSOPT2 :
                //<Class Item Decs Opt> ::= 
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_CLASSITEM :
                //<Class Item> ::= <Constant Dec>
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_CLASSITEM2 :
                //<Class Item> ::= <Field Dec>
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_CLASSITEM3 :
                //<Class Item> ::= <Method Dec>
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_CLASSITEM4 :
                //<Class Item> ::= <Property Dec>
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_CLASSITEM5 :
                //<Class Item> ::= <Event Dec>
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_CLASSITEM6 :
                //<Class Item> ::= <Indexer Dec>
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_CLASSITEM7 :
                //<Class Item> ::= <Operator Dec>
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_CLASSITEM8 :
                //<Class Item> ::= <Constructor Dec>
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_CLASSITEM9 :
                //<Class Item> ::= <Destructor Dec>
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_CLASSITEM10 :
                //<Class Item> ::= <Type Decl>
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_CONSTANTDEC_CONST_SEMI :
                //<Constant Dec> ::= <Header> const <Type> <Constant Declarators> ';'
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_FIELDDEC_SEMI :
                //<Field Dec> ::= <Header> <Type> <Variable Decs> ';'
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_METHODDEC_LPARAN_RPARAN :
                //<Method Dec> ::= <Header> <Type> <Qualified ID> '(' <Formal Param List Opt> ')' <Block or Semi>
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_FORMALPARAMLISTOPT :
                //<Formal Param List Opt> ::= <Formal Param List>
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_FORMALPARAMLISTOPT2 :
                //<Formal Param List Opt> ::= 
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_FORMALPARAMLIST :
                //<Formal Param List> ::= <Formal Param>
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_FORMALPARAMLIST_COMMA :
                //<Formal Param List> ::= <Formal Param List> ',' <Formal Param>
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_FORMALPARAM_IDENTIFIER :
                //<Formal Param> ::= <Attrib Opt> <Type> Identifier
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_FORMALPARAM_REF_IDENTIFIER :
                //<Formal Param> ::= <Attrib Opt> ref <Type> Identifier
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_FORMALPARAM_OUT_IDENTIFIER :
                //<Formal Param> ::= <Attrib Opt> out <Type> Identifier
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_FORMALPARAM_PARAMS_IDENTIFIER :
                //<Formal Param> ::= <Attrib Opt> params <Type> Identifier
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_PROPERTYDEC_LBRACE_RBRACE :
                //<Property Dec> ::= <Header> <Type> <Qualified ID> '{' <Accessor Dec> '}'
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_ACCESSORDEC_GET :
                //<Accessor Dec> ::= <Access Opt> get <Block or Semi>
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_ACCESSORDEC_GET_SET :
                //<Accessor Dec> ::= <Access Opt> get <Block or Semi> <Access Opt> set <Block or Semi>
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_ACCESSORDEC_SET :
                //<Accessor Dec> ::= <Access Opt> set <Block or Semi>
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_ACCESSORDEC_SET_GET :
                //<Accessor Dec> ::= <Access Opt> set <Block or Semi> <Access Opt> get <Block or Semi>
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_EVENTDEC_EVENT_SEMI :
                //<Event Dec> ::= <Header> event <Type> <Variable Decs> ';'
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_EVENTDEC_EVENT_LBRACE_RBRACE :
                //<Event Dec> ::= <Header> event <Type> <Qualified ID> '{' <Event Accessor Decs> '}'
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_EVENTACCESSORDECS_ADD :
                //<Event Accessor Decs> ::= add <Block or Semi>
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_EVENTACCESSORDECS_ADD_REMOVE :
                //<Event Accessor Decs> ::= add <Block or Semi> remove <Block or Semi>
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_EVENTACCESSORDECS_REMOVE :
                //<Event Accessor Decs> ::= remove <Block or Semi>
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_EVENTACCESSORDECS_REMOVE_ADD :
                //<Event Accessor Decs> ::= remove <Block or Semi> add <Block or Semi>
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_INDEXERDEC_LBRACKET_RBRACKET_LBRACE_RBRACE :
                //<Indexer Dec> ::= <Header> <Type> <Qualified ID> '[' <Formal Param List> ']' '{' <Accessor Dec> '}'
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_OPERATORDEC :
                //<Operator Dec> ::= <Header> <Overload Operator Decl> <Block or Semi>
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_OPERATORDEC2 :
                //<Operator Dec> ::= <Header> <Conversion Operator Decl> <Block or Semi>
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_OVERLOADOPERATORDECL_OPERATOR_LPARAN_IDENTIFIER_RPARAN :
                //<Overload Operator Decl> ::= <Type> operator <Overload Op> '(' <Type> Identifier ')'
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_OVERLOADOPERATORDECL_OPERATOR_LPARAN_IDENTIFIER_COMMA_IDENTIFIER_RPARAN :
                //<Overload Operator Decl> ::= <Type> operator <Overload Op> '(' <Type> Identifier ',' <Type> Identifier ')'
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_CONVERSIONOPERATORDECL_IMPLICIT_OPERATOR_LPARAN_IDENTIFIER_RPARAN :
                //<Conversion Operator Decl> ::= implicit operator <Type> '(' <Type> Identifier ')'
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_CONVERSIONOPERATORDECL_EXPLICIT_OPERATOR_LPARAN_IDENTIFIER_RPARAN :
                //<Conversion Operator Decl> ::= explicit operator <Type> '(' <Type> Identifier ')'
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_OVERLOADOP_PLUS :
                //<Overload Op> ::= '+'
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_OVERLOADOP_MINUS :
                //<Overload Op> ::= '-'
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_OVERLOADOP_EXCLAM :
                //<Overload Op> ::= '!'
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_OVERLOADOP_TILDE :
                //<Overload Op> ::= '~'
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_OVERLOADOP_PLUSPLUS :
                //<Overload Op> ::= '++'
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_OVERLOADOP_MINUSMINUS :
                //<Overload Op> ::= --
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_OVERLOADOP_TRUE :
                //<Overload Op> ::= true
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_OVERLOADOP_FALSE :
                //<Overload Op> ::= false
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_OVERLOADOP_TIMES :
                //<Overload Op> ::= '*'
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_OVERLOADOP_DIV :
                //<Overload Op> ::= '/'
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_OVERLOADOP_PERCENT :
                //<Overload Op> ::= '%'
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_OVERLOADOP_AMP :
                //<Overload Op> ::= '&'
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_OVERLOADOP_PIPE :
                //<Overload Op> ::= '|'
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_OVERLOADOP_CARET :
                //<Overload Op> ::= '^'
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_OVERLOADOP_LTLT :
                //<Overload Op> ::= '<<'
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_OVERLOADOP_GTGT :
                //<Overload Op> ::= '>>'
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_OVERLOADOP_EQEQ :
                //<Overload Op> ::= '=='
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_OVERLOADOP_EXCLAMEQ :
                //<Overload Op> ::= '!='
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_OVERLOADOP_GT :
                //<Overload Op> ::= '>'
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_OVERLOADOP_LT :
                //<Overload Op> ::= '<'
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_OVERLOADOP_GTEQ :
                //<Overload Op> ::= '>='
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_OVERLOADOP_LTEQ :
                //<Overload Op> ::= '<='
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_CONSTRUCTORDEC :
                //<Constructor Dec> ::= <Header> <Constructor Declarator> <Block or Semi>
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_CONSTRUCTORDECLARATOR_IDENTIFIER_LPARAN_RPARAN :
                //<Constructor Declarator> ::= Identifier '(' <Formal Param List Opt> ')' <Constructor Init Opt>
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_CONSTRUCTORINITOPT :
                //<Constructor Init Opt> ::= <Constructor Init>
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_CONSTRUCTORINITOPT2 :
                //<Constructor Init Opt> ::= 
                //todo: Create a new object using the stored user objects.
                Helper.InsideConstructor = true;
                return null;

                case (int)RuleConstants.RULE_CONSTRUCTORINIT_COLON_BASE_LPARAN_RPARAN :
                //<Constructor Init> ::= ':' base '(' <Arg List Opt> ')'
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_CONSTRUCTORINIT_COLON_THIS_LPARAN_RPARAN :
                //<Constructor Init> ::= ':' this '(' <Arg List Opt> ')'
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_DESTRUCTORDEC_TILDE_IDENTIFIER_LPARAN_RPARAN :
                //<Destructor Dec> ::= <Header> '~' Identifier '(' ')' <Block>
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_STRUCTDECL_STRUCT_IDENTIFIER_LBRACE_RBRACE :
                //<Struct Decl> ::= <Header> struct Identifier <Class Base Opt> '{' <Class Item Decs Opt> '}' <Semicolon Opt>
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_ARRAYINITIALIZEROPT :
                //<Array Initializer Opt> ::= <Array Initializer>
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_ARRAYINITIALIZEROPT2 :
                //<Array Initializer Opt> ::= 
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_ARRAYINITIALIZER_LBRACE_RBRACE :
                //<Array Initializer> ::= '{' <Variable Initializer List Opt> '}'
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_ARRAYINITIALIZER_LBRACE_COMMA_RBRACE :
                //<Array Initializer> ::= '{' <Variable Initializer List> ',' '}'
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_VARIABLEINITIALIZERLISTOPT :
                //<Variable Initializer List Opt> ::= <Variable Initializer List>
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_VARIABLEINITIALIZERLISTOPT2 :
                //<Variable Initializer List Opt> ::= 
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_VARIABLEINITIALIZERLIST :
                //<Variable Initializer List> ::= <Variable Initializer>
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_VARIABLEINITIALIZERLIST_COMMA :
                //<Variable Initializer List> ::= <Variable Initializer List> ',' <Variable Initializer>
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_INTERFACEDECL_INTERFACE_IDENTIFIER_LBRACE_RBRACE :
                //<Interface Decl> ::= <Header> interface Identifier <Interface Base Opt> '{' <Interface Item Decs Opt> '}' <Semicolon Opt>
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_INTERFACEBASEOPT_COLON :
                //<Interface Base Opt> ::= ':' <Class Base List>
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_INTERFACEBASEOPT :
                //<Interface Base Opt> ::= 
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_INTERFACEITEMDECSOPT :
                //<Interface Item Decs Opt> ::= <Interface Item Decs Opt> <Interface Item Dec>
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_INTERFACEITEMDECSOPT2 :
                //<Interface Item Decs Opt> ::= 
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_INTERFACEITEMDEC :
                //<Interface Item Dec> ::= <Interface Method Dec>
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_INTERFACEITEMDEC2 :
                //<Interface Item Dec> ::= <Interface Property Dec>
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_INTERFACEITEMDEC3 :
                //<Interface Item Dec> ::= <Interface Event Dec>
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_INTERFACEITEMDEC4 :
                //<Interface Item Dec> ::= <Interface Indexer Dec>
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_INTERFACEMETHODDEC_IDENTIFIER_LPARAN_RPARAN :
                //<Interface Method Dec> ::= <Attrib Opt> <New Opt> <Type> Identifier '(' <Formal Param List Opt> ')' <Interface Empty Body>
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_NEWOPT_NEW :
                //<New Opt> ::= new
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_NEWOPT :
                //<New Opt> ::= 
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_INTERFACEPROPERTYDEC_IDENTIFIER_LBRACE_RBRACE :
                //<Interface Property Dec> ::= <Attrib Opt> <New Opt> <Type> Identifier '{' <Interface Accessors> '}'
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_INTERFACEINDEXERDEC_THIS_LBRACKET_RBRACKET_LBRACE_RBRACE :
                //<Interface Indexer Dec> ::= <Attrib Opt> <New Opt> <Type> this '[' <Formal Param List> ']' '{' <Interface Accessors> '}'
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_INTERFACEACCESSORS_GET :
                //<Interface Accessors> ::= <Attrib Opt> <Access Opt> get <Interface Empty Body>
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_INTERFACEACCESSORS_SET :
                //<Interface Accessors> ::= <Attrib Opt> <Access Opt> set <Interface Empty Body>
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_INTERFACEACCESSORS_GET_SET :
                //<Interface Accessors> ::= <Attrib Opt> <Access Opt> get <Interface Empty Body> <Attrib Opt> <Access Opt> set <Interface Empty Body>
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_INTERFACEACCESSORS_SET_GET :
                //<Interface Accessors> ::= <Attrib Opt> <Access Opt> set <Interface Empty Body> <Attrib Opt> <Access Opt> get <Interface Empty Body>
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_INTERFACEEVENTDEC_EVENT_IDENTIFIER :
                //<Interface Event Dec> ::= <Attrib Opt> <New Opt> event <Type> Identifier <Interface Empty Body>
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_INTERFACEEMPTYBODY_SEMI :
                //<Interface Empty Body> ::= ';'
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_INTERFACEEMPTYBODY_LBRACE_RBRACE :
                //<Interface Empty Body> ::= '{' '}'
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_ENUMDECL_ENUM_IDENTIFIER :
                //<Enum Decl> ::= <Header> enum Identifier <Enum Base Opt> <Enum Body> <Semicolon Opt>
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_ENUMBASEOPT_COLON :
                //<Enum Base Opt> ::= ':' <Integral Type>
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_ENUMBASEOPT :
                //<Enum Base Opt> ::= 
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_ENUMBODY_LBRACE_RBRACE :
                //<Enum Body> ::= '{' <Enum Item Decs Opt> '}'
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_ENUMBODY_LBRACE_COMMA_RBRACE :
                //<Enum Body> ::= '{' <Enum Item Decs> ',' '}'
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_ENUMITEMDECSOPT :
                //<Enum Item Decs Opt> ::= <Enum Item Decs>
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_ENUMITEMDECSOPT2 :
                //<Enum Item Decs Opt> ::= 
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_ENUMITEMDECS :
                //<Enum Item Decs> ::= <Enum Item Dec>
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_ENUMITEMDECS_COMMA :
                //<Enum Item Decs> ::= <Enum Item Decs> ',' <Enum Item Dec>
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_ENUMITEMDEC_IDENTIFIER :
                //<Enum Item Dec> ::= <Attrib Opt> Identifier
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_ENUMITEMDEC_IDENTIFIER_EQ :
                //<Enum Item Dec> ::= <Attrib Opt> Identifier '=' <Expression>
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_DELEGATEDECL_DELEGATE_IDENTIFIER_LPARAN_RPARAN_SEMI :
                //<Delegate Decl> ::= <Header> delegate <Type> Identifier '(' <Formal Param List Opt> ')' ';'
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_ATTRIBOPT :
                //<Attrib Opt> ::= <Attrib Opt> <Attrib Section>
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_ATTRIBOPT2 :
                //<Attrib Opt> ::= 
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_ATTRIBSECTION_LBRACKET_RBRACKET :
                //<Attrib Section> ::= '[' <Attrib Target Spec Opt> <Attrib List> ']'
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_ATTRIBSECTION_LBRACKET_COMMA_RBRACKET :
                //<Attrib Section> ::= '[' <Attrib Target Spec Opt> <Attrib List> ',' ']'
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_ATTRIBTARGETSPECOPT_ASSEMBLY_COLON :
                //<Attrib Target Spec Opt> ::= assembly ':'
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_ATTRIBTARGETSPECOPT_FIELD_COLON :
                //<Attrib Target Spec Opt> ::= field ':'
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_ATTRIBTARGETSPECOPT_EVENT_COLON :
                //<Attrib Target Spec Opt> ::= event ':'
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_ATTRIBTARGETSPECOPT_METHOD_COLON :
                //<Attrib Target Spec Opt> ::= method ':'
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_ATTRIBTARGETSPECOPT_MODULE_COLON :
                //<Attrib Target Spec Opt> ::= module ':'
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_ATTRIBTARGETSPECOPT_PARAM_COLON :
                //<Attrib Target Spec Opt> ::= param ':'
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_ATTRIBTARGETSPECOPT_PROPERTY_COLON :
                //<Attrib Target Spec Opt> ::= property ':'
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_ATTRIBTARGETSPECOPT_RETURN_COLON :
                //<Attrib Target Spec Opt> ::= return ':'
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_ATTRIBTARGETSPECOPT_TYPE_COLON :
                //<Attrib Target Spec Opt> ::= type ':'
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_ATTRIBTARGETSPECOPT :
                //<Attrib Target Spec Opt> ::= 
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_ATTRIBLIST :
                //<Attrib List> ::= <Attribute>
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_ATTRIBLIST_COMMA :
                //<Attrib List> ::= <Attrib List> ',' <Attribute>
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_ATTRIBUTE_LPARAN_RPARAN :
                //<Attribute> ::= <Qualified ID> '(' <Expression List> ')'
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_ATTRIBUTE_LPARAN_RPARAN2 :
                //<Attribute> ::= <Qualified ID> '(' ')'
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_ATTRIBUTE :
                //<Attribute> ::= <Qualified ID>
                //todo: Create a new object using the stored user objects.
                return null;

            }
            throw new RuleException("Unknown rule");
        }

        private void AcceptEvent(LALRParser parser, AcceptEventArgs args)
        {
            //todo: Use your fully reduced args.Token.UserObject
        }

        private void TokenErrorEvent(LALRParser parser, TokenErrorEventArgs args)
        {
            string message = "Token error with input: '"+args.Token.ToString()+"'";
            //todo: Report message to UI?
        }

        private void ParseErrorEvent(LALRParser parser, ParseErrorEventArgs args)
        {
            string message = "Parse error caused by token: '"+args.UnexpectedToken.ToString()+"'";
            //todo: Report message to UI?
        }
    }
}
