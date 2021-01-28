// Skipping function Login(none), it contains poisonous unsupported syntaxes

// Skipping function RegistrarUsuario(none), it contains poisonous unsupported syntaxes

// Skipping function ValidarRegistro(none, none), it contains poisonous unsupported syntaxes

// Skipping function enviarCorreo(none, i32), it contains poisonous unsupported syntaxes

// Skipping function AgregarUsuariosLobby(none), it contains poisonous unsupported syntaxes

func @_Contratos.Servicios.NotificarDeNuevoUsuario$$() -> () loc("C:\\Users\\jhoni\\Documents\\Memorama Proyecto\\Memorama-Host\\Contratos\\Servicios.cs" :181 :8) {
^entry :
br ^0

^0: // SimpleBlock
%0 = cbde.unknown : none loc("C:\\Users\\jhoni\\Documents\\Memorama Proyecto\\Memorama-Host\\Contratos\\Servicios.cs" :185 :16) // Not a variable of known type: Callback
%1 = cbde.unknown : none loc("C:\\Users\\jhoni\\Documents\\Memorama Proyecto\\Memorama-Host\\Contratos\\Servicios.cs" :185 :43) // Not a variable of known type: usuariosMensaje
%2 = cbde.unknown : none loc("C:\\Users\\jhoni\\Documents\\Memorama Proyecto\\Memorama-Host\\Contratos\\Servicios.cs" :185 :16) // Callback.GetUsuariosOnline(usuariosMensaje) (InvocationExpression)
br ^1

^1: // ExitBlock
return

}
// Skipping function EnviarMensaje(none, none), it contains poisonous unsupported syntaxes

// Skipping function GetSourceUser(), it contains poisonous unsupported syntaxes

// Skipping function RankingUsuarios(), it contains poisonous unsupported syntaxes

func @_Contratos.Servicios.GenerarTablero$System.Random$(none) -> none loc("C:\\Users\\jhoni\\Documents\\Memorama Proyecto\\Memorama-Host\\Contratos\\Servicios.cs" :241 :8) {
^entry (%_random : none):
%0 = cbde.alloca none loc("C:\\Users\\jhoni\\Documents\\Memorama Proyecto\\Memorama-Host\\Contratos\\Servicios.cs" :241 :40)
cbde.store %_random, %0 : memref<none> loc("C:\\Users\\jhoni\\Documents\\Memorama Proyecto\\Memorama-Host\\Contratos\\Servicios.cs" :241 :40)
br ^0

^0: // SimpleBlock
%1 = cbde.unknown : none loc("C:\\Users\\jhoni\\Documents\\Memorama Proyecto\\Memorama-Host\\Contratos\\Servicios.cs" :243 :22) // Not a variable of known type: globalTablero
%2 = cbde.unknown : none loc("C:\\Users\\jhoni\\Documents\\Memorama Proyecto\\Memorama-Host\\Contratos\\Servicios.cs" :244 :20) // Not a variable of known type: tablero
%3 = cbde.unknown : i32 loc("C:\\Users\\jhoni\\Documents\\Memorama Proyecto\\Memorama-Host\\Contratos\\Servicios.cs" :244 :20) // tablero.Count (SimpleMemberAccessExpression)
%4 = cbde.alloca i32 loc("C:\\Users\\jhoni\\Documents\\Memorama Proyecto\\Memorama-Host\\Contratos\\Servicios.cs" :244 :16) // n
cbde.store %3, %4 : memref<i32> loc("C:\\Users\\jhoni\\Documents\\Memorama Proyecto\\Memorama-Host\\Contratos\\Servicios.cs" :244 :16)
br ^1

^1: // BinaryBranchBlock
%5 = cbde.load %4 : memref<i32> loc("C:\\Users\\jhoni\\Documents\\Memorama Proyecto\\Memorama-Host\\Contratos\\Servicios.cs" :245 :19)
%6 = constant 1 : i32 loc("C:\\Users\\jhoni\\Documents\\Memorama Proyecto\\Memorama-Host\\Contratos\\Servicios.cs" :245 :23)
%7 = cmpi "sgt", %5, %6 : i32 loc("C:\\Users\\jhoni\\Documents\\Memorama Proyecto\\Memorama-Host\\Contratos\\Servicios.cs" :245 :19)
cond_br %7, ^2, ^3 loc("C:\\Users\\jhoni\\Documents\\Memorama Proyecto\\Memorama-Host\\Contratos\\Servicios.cs" :245 :19)

^2: // SimpleBlock
%8 = cbde.load %4 : memref<i32> loc("C:\\Users\\jhoni\\Documents\\Memorama Proyecto\\Memorama-Host\\Contratos\\Servicios.cs" :247 :16)
%9 = constant 1 : i32 loc("C:\\Users\\jhoni\\Documents\\Memorama Proyecto\\Memorama-Host\\Contratos\\Servicios.cs" :247 :16)
%10 = subi %8, %9 : i32 loc("C:\\Users\\jhoni\\Documents\\Memorama Proyecto\\Memorama-Host\\Contratos\\Servicios.cs" :247 :16)
cbde.store %10, %4 : memref<i32> loc("C:\\Users\\jhoni\\Documents\\Memorama Proyecto\\Memorama-Host\\Contratos\\Servicios.cs" :247 :16)
%11 = cbde.unknown : none loc("C:\\Users\\jhoni\\Documents\\Memorama Proyecto\\Memorama-Host\\Contratos\\Servicios.cs" :248 :24) // Not a variable of known type: random
%12 = cbde.load %4 : memref<i32> loc("C:\\Users\\jhoni\\Documents\\Memorama Proyecto\\Memorama-Host\\Contratos\\Servicios.cs" :248 :36)
%13 = constant 1 : i32 loc("C:\\Users\\jhoni\\Documents\\Memorama Proyecto\\Memorama-Host\\Contratos\\Servicios.cs" :248 :40)
%14 = addi %12, %13 : i32 loc("C:\\Users\\jhoni\\Documents\\Memorama Proyecto\\Memorama-Host\\Contratos\\Servicios.cs" :248 :36)
%15 = cbde.unknown : i32 loc("C:\\Users\\jhoni\\Documents\\Memorama Proyecto\\Memorama-Host\\Contratos\\Servicios.cs" :248 :24) // random.Next(n + 1) (InvocationExpression)
%16 = cbde.alloca i32 loc("C:\\Users\\jhoni\\Documents\\Memorama Proyecto\\Memorama-Host\\Contratos\\Servicios.cs" :248 :20) // k
cbde.store %15, %16 : memref<i32> loc("C:\\Users\\jhoni\\Documents\\Memorama Proyecto\\Memorama-Host\\Contratos\\Servicios.cs" :248 :20)
%17 = cbde.unknown : none loc("C:\\Users\\jhoni\\Documents\\Memorama Proyecto\\Memorama-Host\\Contratos\\Servicios.cs" :249 :28) // Not a variable of known type: tablero
%18 = cbde.load %16 : memref<i32> loc("C:\\Users\\jhoni\\Documents\\Memorama Proyecto\\Memorama-Host\\Contratos\\Servicios.cs" :249 :36)
%19 = cbde.unknown : i32 loc("C:\\Users\\jhoni\\Documents\\Memorama Proyecto\\Memorama-Host\\Contratos\\Servicios.cs" :249 :28) // tablero[k] (ElementAccessExpression)
%20 = cbde.alloca i32 loc("C:\\Users\\jhoni\\Documents\\Memorama Proyecto\\Memorama-Host\\Contratos\\Servicios.cs" :249 :20) // value
cbde.store %19, %20 : memref<i32> loc("C:\\Users\\jhoni\\Documents\\Memorama Proyecto\\Memorama-Host\\Contratos\\Servicios.cs" :249 :20)
%21 = cbde.unknown : none loc("C:\\Users\\jhoni\\Documents\\Memorama Proyecto\\Memorama-Host\\Contratos\\Servicios.cs" :250 :16) // Not a variable of known type: tablero
%22 = cbde.load %16 : memref<i32> loc("C:\\Users\\jhoni\\Documents\\Memorama Proyecto\\Memorama-Host\\Contratos\\Servicios.cs" :250 :24)
%23 = cbde.unknown : i32 loc("C:\\Users\\jhoni\\Documents\\Memorama Proyecto\\Memorama-Host\\Contratos\\Servicios.cs" :250 :16) // tablero[k] (ElementAccessExpression)
%24 = cbde.unknown : none loc("C:\\Users\\jhoni\\Documents\\Memorama Proyecto\\Memorama-Host\\Contratos\\Servicios.cs" :250 :29) // Not a variable of known type: tablero
%25 = cbde.load %4 : memref<i32> loc("C:\\Users\\jhoni\\Documents\\Memorama Proyecto\\Memorama-Host\\Contratos\\Servicios.cs" :250 :37)
%26 = cbde.unknown : i32 loc("C:\\Users\\jhoni\\Documents\\Memorama Proyecto\\Memorama-Host\\Contratos\\Servicios.cs" :250 :29) // tablero[n] (ElementAccessExpression)
%27 = cbde.unknown : none loc("C:\\Users\\jhoni\\Documents\\Memorama Proyecto\\Memorama-Host\\Contratos\\Servicios.cs" :251 :16) // Not a variable of known type: tablero
%28 = cbde.load %4 : memref<i32> loc("C:\\Users\\jhoni\\Documents\\Memorama Proyecto\\Memorama-Host\\Contratos\\Servicios.cs" :251 :24)
%29 = cbde.unknown : i32 loc("C:\\Users\\jhoni\\Documents\\Memorama Proyecto\\Memorama-Host\\Contratos\\Servicios.cs" :251 :16) // tablero[n] (ElementAccessExpression)
%30 = cbde.load %20 : memref<i32> loc("C:\\Users\\jhoni\\Documents\\Memorama Proyecto\\Memorama-Host\\Contratos\\Servicios.cs" :251 :29)
br ^1

^3: // JumpBlock
%31 = cbde.unknown : none loc("C:\\Users\\jhoni\\Documents\\Memorama Proyecto\\Memorama-Host\\Contratos\\Servicios.cs" :253 :19) // Not a variable of known type: tablero
return %31 : none loc("C:\\Users\\jhoni\\Documents\\Memorama Proyecto\\Memorama-Host\\Contratos\\Servicios.cs" :253 :12)

^4: // ExitBlock
cbde.unreachable

}
// Skipping function HacerMovimiento(i32, i32), it contains poisonous unsupported syntaxes

// Skipping function PasarCarta(i32), it contains poisonous unsupported syntaxes

// Skipping function CartaEquivocada(), it contains poisonous unsupported syntaxes

// Skipping function LogOutLobby(none), it contains poisonous unsupported syntaxes

// Skipping function AgregarPuntuacion(none, i32), it contains poisonous unsupported syntaxes

// Skipping function BuscarParaCambiarContraseña(none, none), it contains poisonous unsupported syntaxes

// Skipping function CambiarContraseña(none, none), it contains poisonous unsupported syntaxes

// Skipping function validarCodigoContraseña(none, none), it contains poisonous unsupported syntaxes

// Skipping function verificarReportes(none), it contains poisonous unsupported syntaxes

// Skipping function Empezarjuego(), it contains poisonous unsupported syntaxes

