using Clase6;

//instanciando clase
Humano Marco = new Humano(primerNombre: "Marco");
Marco.presentarse();

Humano Aroldo = new Humano(primerNombre: "Aroldo", primerApellido: "Nájera");
Aroldo.presentarse();

Humano Jose = new Humano(primerNombre: "Jose", primerApellido: "Perez", colorDeOjos: "Verdes");
Jose.presentarse();

//Caja
Caja Caja1 = new Caja(ancho: 10, alto: 20, largo: 30);
Console.WriteLine("\n El largo es " + Caja1.getLargo());
Console.WriteLine("El ancho es " + Caja1.getAncho());
Console.WriteLine("El alto es " + Caja1.getAlto());
Console.WriteLine("La superficie frontal es de " + Caja1.superficieFrontal() );