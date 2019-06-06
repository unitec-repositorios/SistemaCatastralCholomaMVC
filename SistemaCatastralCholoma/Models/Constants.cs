using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace SistemaCatastralCholoma.Models
{

    [AttributeUsage(AttributeTargets.All)]
    public class Descripcion : DescriptionAttribute
    {

        public Descripcion(string descripcion)
        {
            this.descripcion = descripcion;
        }

        public Descripcion(string descripcion, string valor)
        {
            this.descripcion = descripcion;
            this.valor = valor;
        }

        public string descripcion { get; set; }
        public string valor { get; set; }
    }

    public enum USO
    {
        [Descripcion("COMERCIAL PURO")]
        U2,
        [Descripcion("INDUSTRIAL PURO")]
        U3,
        [Descripcion("RESIDENCIAL/COMERCIAL")]
        U4,
        [Descripcion("RESIDENCIAL/INDUSTRIAL")]
        U5,
        [Descripcion("COMERCIAL/INDUSTRIAL")]
        U6,
        [Descripcion("RECREACIONAL(PARQUES, AREAS VERDES")]
        U7,
        [Descripcion("INSTITUCIONAL (GOBIERNO Y OTRAS IN")]
        U8,
        [Descripcion("RESIDENCIAL PURO")]
        U1,
        [Descripcion("MUNICIPAL")]
        U9,
        [Descripcion("PREDIO BALDIO")]
        U10,
        [Descripcion("PREDIO RURAL")]
        U0,

    }
    public enum SUBUSO
    {
        [Descripcion("Apartamentos (Mas de tres Familias")]
        U1SU4,
        [Descripcion("3 Familias")]
        U1SU3,
        [Descripcion("CANTERA")]
        U3SUE1,
        [Descripcion("Abogado (Bufete)")]
        U2SU1,
        [Descripcion("Cuarterias")]
        U1SU5,
        [Descripcion("1 Familia")]
        U1SU1,
        [Descripcion("Baldio")]
        U1SU0,
        [Descripcion("2 Familias")]
        U1SU2,
        [Descripcion("ACADEMIA DE COSTURA")]
        U2SU2,
        [Descripcion("academia de Belleza")]
        U2SU3,
        [Descripcion("TIENDA DE ACCESORIOS ELECTRIC  ")]
        U2SU4,
        [Descripcion("TIENDA DE ACCES PARA AUTOS  ")]
        U2SU5,
        [Descripcion("AGENCIA ADUANERAS  ")]
        U2SU6,
        [Descripcion("TALLER Y VENTA DE REPUESTOS ")]
        U2SUD7,
        [Descripcion("Bazar")]
        U2SU7,
        [Descripcion("Agencia de Embarque")]
        U2SU8,
        [Descripcion("Agencia de Viajes")]
        U2SU9,
        [Descripcion("Agencias MarÂ¡tima")]
        U2SU10,
        [Descripcion("Efectos AgrÂ¡colas")]
        U2SU11,
        [Descripcion("Equipo de Agricultura")]
        U2SU12,
        [Descripcion("InstituciÂ¢n de Ahorro y Prâ€šstamo")]
        U2SU13,
        [Descripcion("Aire Acondicionado (Taller de Repa")]
        U2SU14,
        [Descripcion("Oficina de Limpieza")]
        U2SU15,
        [Descripcion("Almacen de depÂ¢sito")]
        U2SU16,
        [Descripcion("Venta de Productos de Aluminio")]
        U2SU17,
        [Descripcion("Venta de Animales")]
        U2SU18,
        [Descripcion("AplanchadurÂ¡a y LavanderÂ¡a")]
        U2SU19,
        [Descripcion("Oficina de Arquitectos")]
        U2SU20,
        [Descripcion("Oficina de Ingenieros")]
        U2SU21,
        [Descripcion("FloristerÂ¡a")]
        U2SU22,
        [Descripcion("LibrerÂ¡a")]
        U2SU23,
        [Descripcion("Venta ArtesanÂ¡a")]
        U2SU24,
        [Descripcion("Venta de Automoviles")]
        U2SU25,
        [Descripcion("Auto Escuela")]
        U2SU26,
        [Descripcion("Alquiler AutomÂ¢viles")]
        U2SU27,
        [Descripcion("Tiendas de Pintura")]
        U2SU28,
        [Descripcion("Oficina CÂ¡a. De AviaciÂ¢n")]
        U2SU29,
        [Descripcion("Taller de BalconerÂ¡a")]
        U2SU30,
        [Descripcion("Banco")]
        U2SU31,
        [Descripcion("Bar")]
        U2SU32,
        [Descripcion("Oficina Bienes Raices")]
        U2SU33,
        [Descripcion("HospederÂ¡a")]
        U2SU34,
        [Descripcion("Hotel")]
        U2SU35,
        [Descripcion("Venta de Calzado")]
        U2SU36,
        [Descripcion("Taller de CarpinterÂ¡a")]
        U2SU37,
        [Descripcion("Taller ReparaciÂ¢n de Radios, T.V.")]
        U2SU38,
        [Descripcion("Taller de ReparaciÂ¢n Automoviles")]
        U2SU39,
        [Descripcion("CarnicerÂ¡as")]
        U2SU40,
        [Descripcion("Cine")]
        U2SU41,
        [Descripcion("CerrajerÂ¡a")]
        U2SU42,
        [Descripcion("JoyerÂ¡a")]
        U2SU43,
        [Descripcion("Colegio e Instituto (Privados)")]
        U2SU44,
        [Descripcion("Oficina de ComputaciÂ¢n")]
        U2SU45,
        [Descripcion("FerreterÂ¡a")]
        U2SU46,
        [Descripcion("Discoteca")]
        U2SU47,
        [Descripcion("Venta de Discos")]
        U2SU48,
        [Descripcion("Drive-Inn")]
        U2SU49,
        [Descripcion("DroguerÂ¡a")]
        U2SU50,
        [Descripcion("Venta de Electrodomesticos")]
        U2SU51,
        [Descripcion("Venta de Efectos Plasticos")]
        U2SU52,
        [Descripcion("Farmacia")]
        U2SU53,
        [Descripcion("Estudios FotogrÂ ficos")]
        U2SU54,
        [Descripcion("Funerarias")]
        U2SU55,
        [Descripcion("Venta de Gases")]
        U2SU56,
        [Descripcion("Gasolineras")]
        U2SU57,
        [Descripcion("Gimnasio")]
        U2SU58,
        [Descripcion("Venta de Hamburgesas (Comida Liger")]
        U2SU59,
        [Descripcion("CafeterÂ¡a")]
        U2SU60,
        [Descripcion("Venta de Helados")]
        U2SU61,
        [Descripcion("Imprenta")]
        U2SU62,
        [Descripcion("JardÂ¡n de NiÂ¤os (Privado)")]
        U2SU63,
        [Descripcion("Laboratorio ClÂ¡nico")]
        U2SU64,
        [Descripcion("Venta de Licores")]
        U2SU65,
        [Descripcion("Venta de Llantas")]
        U2SU66,
        [Descripcion("Venta de Maderas")]
        U2SU67,
        [Descripcion("Motel")]
        U2SU68,
        [Descripcion("MueblerÂ¡a")]
        U2SU69,
        [Descripcion("Optica")]
        U2SU70,
        [Descripcion("PapelerÂ¡a")]
        U2SU71,
        [Descripcion("PizzerÂ¡a")]
        U2SU72,
        [Descripcion("EstaciÂ¢n Radio o T.V.")]
        U2SU73,
        [Descripcion("DepÂ¢sito de Refrescos")]
        U2SU74,
        [Descripcion("Taller de Tapizado")]
        U2SU75,
        [Descripcion("CompaÂ¤Â¡a de Seguros")]
        U2SU76,
        [Descripcion("Transporte Terrestre")]
        U2SU77,
        [Descripcion("SastrerÂ¡as")]
        U2SU78,
        [Descripcion("Billar")]
        U2SU79,
        [Descripcion("Caseta Protectora de Bombas")]
        U2SU80,
        [Descripcion("Empresa de Vapores")]
        U2SU81,
        [Descripcion("PulperÂ¡a, Billares y Hotel")]
        U2SU82,
        [Descripcion("Bar y Billares")]
        U2SU83,
        [Descripcion("Tienda y Bancos")]
        U2SU84,
        [Descripcion("Distribuidoras de Carne")]
        U2SU85,
        [Descripcion("ClÂ¡nica y Casa de EmpeÂ¤o")]
        U2SU86,
        [Descripcion("DepÂ¢sito de Contenedores")]
        U2SU87,
        [Descripcion("Tienda y Supermercados")]
        U2SU88,
        [Descripcion("Tienda, Restaurante y zapaterÂ¡a")]
        U2SU89,
        [Descripcion("Hotel, Restaurante y Farmacia")]
        U2SU90,
        [Descripcion("ZapaterÂ¡a, Oficina y Foto estudio")]
        U2SU91,
        [Descripcion("Agencia de Viajes, Tienda Agropecu")]
        U2SU92,
        [Descripcion("Bar, Hotel")]
        U2SU93,
        [Descripcion("Oficina y Hospedaje")]
        U2SU94,
        [Descripcion("ClÂ¡nica y Tienda Agropecuaria")]
        U2SU95,
        [Descripcion("Cine, Tienda, FerreterÂ¡a y Billare")]
        U2SU96,
        [Descripcion("Oficina, Bodega y Cementerio Priva")]
        U2SU97,
        [Descripcion("Gasolinera y CafeterÂ¡a")]
        U2SU98,
        [Descripcion("PulperÂ¡a y  Billar")]
        U2SU99,
        [Descripcion("DepÂ¢sito y AbarroterÂ¡a")]
        U2SUA1,
        [Descripcion("Glorieta y Billar")]
        U2SUA2,
        [Descripcion("PulperÂ¡a")]
        U2SUA3,
        [Descripcion("Restaurante")]
        U2SUA4,
        [Descripcion("PulperÂ¡a y Molino")]
        U2SUA5,
        [Descripcion("PORQUERIZAS  ")]
        U2SUD6,
        [Descripcion("Supermercado")]
        U2SUA6,
        [Descripcion("Molino")]
        U2SUA7,
        [Descripcion("Hospedaje")]
        U2SUA8,
        [Descripcion("Hotel y Centro Comercial")]
        U2SUA9,
        [Descripcion("Distribuidora")]
        U2SUB1,
        [Descripcion("Tienda y AbarroterÂ¡a")]
        U2SUB2,
        [Descripcion("Prostibulo o Casa de Citas")]
        U2SUB3,
        [Descripcion("Bodega")]
        U2SUB4,
        [Descripcion("Terminal de Transporte")]
        U2SUB5,
        [Descripcion("TalabarterÂ¡a")]
        U2SUB6,
        [Descripcion("Oficinas")]
        U2SUB7,
        [Descripcion("Sala de Belleza")]
        U2SUB8,
        [Descripcion("Comercial y Billares")]
        U2SUB9,
        [Descripcion("Centro Comercial")]
        U2SUC1,
        [Descripcion("Oficinas y Tiendas")]
        U2SUC2,
        [Descripcion("ClÂ¡nica Dental")]
        U2SUC3,
        [Descripcion("Tienda y BarberÂ¡a")]
        U2SUC4,
        [Descripcion("Escuela de Ballet")]
        U2SUC5,
        [Descripcion("Centro Comercial y Apartamentos")]
        U2SUC6,
        [Descripcion("ClÂ¡nicas")]
        U2SUC7,
        [Descripcion("Parqueo")]
        U2SUC8,
        [Descripcion("ReposterÂ¡a")]
        U2SUC9,
        [Descripcion("PanaderÂ¡a")]
        U2SUD1,
        [Descripcion("Reparadora de Llantas")]
        U2SUD2,
        [Descripcion("Centro TurÂ¡stico")]
        U2SUD3,
        [Descripcion("Granga AvÂ¡cola")]
        U2SUD4,
        [Descripcion("Banco y CompaÂ¤ia de Seguros")]
        U2SUD5,
        [Descripcion("Baldio")]
        U3SU0,
        [Descripcion("Productos Industrial de Concreto")]
        U3SU1,
        [Descripcion("Fabrica de Aguardiente")]
        U3SU2,
        [Descripcion("Destileria")]
        U3SU3,
        [Descripcion("Fabrica de Alfombras")]
        U3SU4,
        [Descripcion("Fabrica de Productos Alimenticios")]
        U3SU5,
        [Descripcion("Fabrica de Alimentos para Animales")]
        U3SU6,
        [Descripcion("Fabrica de Almidones")]
        U3SU7,
        [Descripcion("Fabrica de Almohadas")]
        U3SU8,
        [Descripcion("Fabrica de Productos Aluminio")]
        U3SU9,
        [Descripcion("Beneficio de Arroz")]
        U3SU10,
        [Descripcion("Fabrica de Muebles de Oficina")]
        U3SU11,
        [Descripcion("Fabrica de Muebles para el Hogar")]
        U3SU12,
        [Descripcion("Aserraderos")]
        U3SU13,
        [Descripcion("Fabricas Baldosas")]
        U3SU14,
        [Descripcion("Fabrica de Bacterias")]
        U3SU15,
        [Descripcion("Fabrica de Betunes para Calzado")]
        U3SU16,
        [Descripcion("Fabrica de Billares")]
        U3SU17,
        [Descripcion("Fabrica de Bloques de Concreto")]
        U3SU18,
        [Descripcion("Fabrica de Botones")]
        U3SU19,
        [Descripcion("FÂ brica de Cafâ€š")]
        U3SU20,
        [Descripcion("FÂ brica Cajas para puros")]
        U3SU21,
        [Descripcion("Fabrica de Calcetines")]
        U3SU22,
        [Descripcion("Fabrica de Cal")]
        U3SU23,
        [Descripcion("Fabrica de camas y colchones")]
        U3SU24,
        [Descripcion("FÂ brica de camisas")]
        U3SU25,
        [Descripcion("Empacadora de Carnes")]
        U3SU26,
        [Descripcion("FÂ brica de Carton")]
        U3SU27,
        [Descripcion("Fabrica de Carteras")]
        U3SU28,
        [Descripcion("FÂ brica de cassettes")]
        U3SU29,
        [Descripcion("Fabrica de Celosias")]
        U3SU30,
        [Descripcion("Fabrica de Cemento")]
        U3SU31,
        [Descripcion("Cerveceria")]
        U3SU32,
        [Descripcion("Fabrica cinta adhesiva")]
        U3SU33,
        [Descripcion("Fabrica de Cocinas")]
        U3SU34,
        [Descripcion("Fabrica de Cohetes y Petardos")]
        U3SU35,
        [Descripcion("Fabrica de Concentrados para Refre")]
        U3SU36,
        [Descripcion("Fabrica de Confites")]
        U3SU37,
        [Descripcion("Fabrica de Conos")]
        U3SU38,
        [Descripcion("Fabrica de Cosmeticos")]
        U3SU39,
        [Descripcion("Fabrica de Cuadernos")]
        U3SU40,
        [Descripcion("Fabrica de Chocolates")]
        U3SU41,
        [Descripcion("Fabrica de Productos Farmaceuticos")]
        U3SU42,
        [Descripcion("Fabrica de Embutidos")]
        U3SU43,
        [Descripcion("Fabrica de Embases Plasticos")]
        U3SU44,
        [Descripcion("Fabrica de Embases Metalicos")]
        U3SU45,
        [Descripcion("Fabrica de Embases de Vidrio")]
        U3SU46,
        [Descripcion("Fabrica de Escobas")]
        U3SU47,
        [Descripcion("Fabrica de  Esponjas")]
        U3SU48,
        [Descripcion("Fabrica de Estructuras Metalicas")]
        U3SU49,
        [Descripcion("Fabrica de Estufas Electricas")]
        U3SU50,
        [Descripcion("Fabrica de Fertilizantes")]
        U3SU51,
        [Descripcion("Fabrica de Fosforos")]
        U3SU52,
        [Descripcion("Fundicion")]
        U3SU53,
        [Descripcion("Fabrica de Galletas")]
        U3SU54,
        [Descripcion("Refineria de Petroleo")]
        U3SU55,
        [Descripcion("Fabrica de Arina de Maiz")]
        U3SU56,
        [Descripcion("Fabrica de Arina de Trigo")]
        U3SU57,
        [Descripcion("Fabrica de Helados")]
        U3SU58,
        [Descripcion("Fabrica de Hielo")]
        U3SU59,
        [Descripcion("FÂ brica de Hilo para Coser")]
        U3SU60,
        [Descripcion("Fabrica de Telas")]
        U3SU61,
        [Descripcion("Fabrica de Incectisidas")]
        U3SU62,
        [Descripcion("Fabrica de Ladrillos Rafon")]
        U3SU63,
        [Descripcion("Fabricas de Ladrillo Cemento")]
        U3SU64,
        [Descripcion("Fabrica de Ladrillos y Mosaicos")]
        U3SU65,
        [Descripcion("Fabricas de Laminas para Techos")]
        U3SU66,
        [Descripcion("Fabrica de Lamparas")]
        U3SU67,
        [Descripcion("Fabrica de Lapices")]
        U3SU68,
        [Descripcion("Fabrica de Lentes")]
        U3SU69,
        [Descripcion("Fabrica de Limas")]
        U3SU70,
        [Descripcion("Fabrica de Losa Sanitaria")]
        U3SU71,
        [Descripcion("Fabrica de Manteca")]
        U3SU72,
        [Descripcion("Fabrica de Maquinaria Agroindustri")]
        U3SU73,
        [Descripcion("Fabrica de Marmol y Fibra")]
        U3SU74,
        [Descripcion("Taller Mecanico Industrial")]
        U3SU75,
        [Descripcion("Fabrica de Molinos")]
        U3SU76,
        [Descripcion("Fabrica de Muebles Mecanicos")]
        U3SU77,
        [Descripcion("Fabrica de Oxigeno y otros Gases")]
        U3SU78,
        [Descripcion("Fabrica de Palillas para Paletas")]
        U3SU79,
        [Descripcion("Fabrica de Pantalones")]
        U3SU80,
        [Descripcion("FABRICA DE CURTIEMBRE ")]
        U3SUC1,
        [Descripcion("Fabrica de Prendas Femeninas")]
        U3SU81,
        [Descripcion("Fabrica de Papel Higienico")]
        U3SU82,
        [Descripcion("Fabrica de Pastas Alimenticias")]
        U3SU83,
        [Descripcion("Fabrica de Pieles")]
        U3SU84,
        [Descripcion("Fabrica de Pinturas")]
        U3SU85,
        [Descripcion("Fabrica de Plwood")]
        U3SU86,
        [Descripcion("Fabrica de Polvos para Hornear")]
        U3SU87,
        [Descripcion("Fabrica de Puertas y Closeth")]
        U3SU88,
        [Descripcion("Fabrica de Refrescos")]
        U3SU89,
        [Descripcion("Fabrica de Resinas")]
        U3SU90,
        [Descripcion("Fabrica de Resortes")]
        U3SU91,
        [Descripcion("Fabrica de Rotulos Luminosas")]
        U3SU92,
        [Descripcion("Fabrica de Salsas")]
        U3SU93,
        [Descripcion("Fabrica de Sellos de Hule")]
        U3SU94,
        [Descripcion("Fabrica de Silenciadores")]
        U3SU95,
        [Descripcion("Fabrica de Soga")]
        U3SU96,
        [Descripcion("Fabrica de Sueteres")]
        U3SU97,
        [Descripcion("Fabrica de Tabaco")]
        U3SU98,
        [Descripcion("Fabrica de Tanques de Agua")]
        U3SU99,
        [Descripcion("Fabrica de Textiles")]
        U3SUA1,
        [Descripcion("Fabrica de Tuallas")]
        U3SUA2,
        [Descripcion("Fabrica de Equipo de Transporte")]
        U3SUA3,
        [Descripcion("Fabrica de Trapiadores")]
        U3SUA4,
        [Descripcion("Fabrica de Tuberia de Concreto")]
        U3SUA5,
        [Descripcion("Fabrica de Tuberia Metalica")]
        U3SUA6,
        [Descripcion("Fabrica de Tuberias PVC")]
        U3SUA7,
        [Descripcion("Fabrica de Vajillas")]
        U3SUA8,
        [Descripcion("Fabrica de Valijas")]
        U3SUA9,
        [Descripcion("Fabrica de Vasos")]
        U3SUB1,
        [Descripcion("Fabrica de Velas")]
        U3SUB2,
        [Descripcion("Fabrica de Vidrios")]
        U3SUB3,
        [Descripcion("Fabrica de ViÂ¤etas")]
        U3SUB4,
        [Descripcion("Fabrica de Yates")]
        U3SUB5,
        [Descripcion("Fabrica de Zipers")]
        U3SUB6,
        [Descripcion("Bodega")]
        U3SUB7,
        [Descripcion("Bodega de Oficinas")]
        U3SUB8,
        [Descripcion("Fabrica de Brochas y Cepillos")]
        U3SUB9,
        [Descripcion("Baldio")]
        U4SU0,
        [Descripcion("Residencial 1 Familia/PulperÂ¡a")]
        U4SU1,
        [Descripcion("Residencial 1 Familia/Farmacia")]
        U4SU2,
        [Descripcion("Residencial 1 Familia/Estanco")]
        U4SU3,
        [Descripcion("Residencial 1 Familia/Tienda")]
        U4SU4,
        [Descripcion("Residencial 1 Familia/Institucione")]
        U4SU5,
        [Descripcion("Residencial 1 Familia/Oficina y Ti")]
        U4SU6,
        [Descripcion("Residencial 1 Familia/PanaderÂ¡a")]
        U4SU7,
        [Descripcion("Residencial 1 Familia/PulperÂ¡a")]
        U4SU8,
        [Descripcion("Residencial 1 Familia/CarnicerÂ¡a")]
        U4SU9,
        [Descripcion("Residencial 1 Familia/AbarroterÂ¡a")]
        U4SU10,
        [Descripcion("Residencial 1 Familia/ClÂ¡nica")]
        U4SU11,
        [Descripcion("Residencial 1 Familia/Restaurante ")]
        U4SU12,
        [Descripcion("Residencial 1 Familia/PulperÂ¡a y B")]
        U4SU13,
        [Descripcion("Residencial 1 Familia/Taller de Re")]
        U4SU14,
        [Descripcion("Residencial 1 Familia/Bodega")]
        U4SU15,
        [Descripcion("Residencial 1 Familia/Agencia Adua")]
        U4SU16,
        [Descripcion("Residencial 1 Familia/IglesÂ¡a")]
        U4SU17,
        [Descripcion("Residencial 1 Familia/Restaurante")]
        U4SU18,
        [Descripcion("Residencial 1 Familia/LibrerÂ¡a")]
        U4SU19,
        [Descripcion("Residencial 1 Familia/JoyerÂ¡a, Res")]
        U4SU20,
        [Descripcion("Residencial 1 Familia/Taller MecÂ n")]
        U4SU21,
        [Descripcion("Residencial 1 Familia/Discoteca")]
        U4SU22,
        [Descripcion("Residencial 1 Familia/Supermercado")]
        U4SU23,
        [Descripcion("Residencial 1 Familia/Billares")]
        U4SU24,
        [Descripcion("Residencial 1 Familia/Oficina")]
        U4SU25,
        [Descripcion("Residencial 1 Familia/LavanderÂ¡a")]
        U4SU26,
        [Descripcion("Residencial 1 Familia/JoyerÂ¡a")]
        U4SU27,
        [Descripcion("Residencial 1 Familia/Bodega, Tall")]
        U4SU28,
        [Descripcion("Residencial 1 Familia/Estudio Foto")]
        U4SU29,
        [Descripcion("Residencial 1 Familia/Casa de Empe")]
        U4SU30,
        [Descripcion("Residencial 1 Familia/PulperÂ¡a, Ta")]
        U4SU31,
        [Descripcion("Residencial 1 Familia/Supermercado")]
        U4SU32,
        [Descripcion("Residencial 1 Familia/Academia de ")]
        U4SU33,
        [Descripcion("Residencial 1 Familia/CarpinterÂ¡a")]
        U4SU34,
        [Descripcion("Residencial 1 Familia/SastrerÂ¡a, A")]
        U4SU35,
        [Descripcion("Residencial 1 Familia/Farmacia, Ti")]
        U4SU36,
        [Descripcion("Residencial 1 Familia/PulperÂ¡a, Pa")]
        U4SU37,
        [Descripcion("Residencial 1 Familia/Agencia Banc")]
        U4SU38,
        [Descripcion("Residencial 1 Familia/Hospedaje, C")]
        U4SU39,
        [Descripcion("Residencial 1 Familia/Agencia Navi")]
        U4SU40,
        [Descripcion("Residencial 1 Familia/CafeterÂ¡a, B")]
        U4SU41,
        [Descripcion("Residencial 1 Familia/Radio Emisor")]
        U4SU42,
        [Descripcion("Residencial 1 Familia/ClÂ¡nica, Gim")]
        U4SU43,
        [Descripcion("Residencial 1 Familia/Agencia Adua")]
        U4SU44,
        [Descripcion("Residencial 1 Familia/Imprenta")]
        U4SU45,
        [Descripcion("Residencial 1 Familia/Taller MecÂ n")]
        U4SU46,
        [Descripcion("Residencial 1 Familia/Agencia de E")]
        U4SU47,
        [Descripcion("Residencial 1 Familia/Hotel ClÂ¡nic")]
        U4SU48,
        [Descripcion("Residencial 1 Familia/FerreterÂ¡a, ")]
        U4SU49,
        [Descripcion("Residencial 1 Familia/BarberÂ¡a")]
        U4SU50,
        [Descripcion("Residencial 1 Familia/Sala de Bell")]
        U4SU51,
        [Descripcion("Residencial 1 Familia/FerreterÂ¡a")]
        U4SU52,
        [Descripcion("Residencial 1 Familia/FerreterÂ¡a, ")]
        U4SU53,
        [Descripcion("Residencial 1 Familia/BarberÂ¡a, Sa")]
        U4SU54,
        [Descripcion("Residencial 1 Familia/Agencia Adua")]
        U4SU55,
        [Descripcion("Residencial 1 Familia/Merendero o ")]
        U4SU56,
        [Descripcion("Residencial 1 Familia/Bodega, Ofic")]
        U4SU57,
        [Descripcion("Residencial 1 Familia/Comedor, Hos")]
        U4SU58,
        [Descripcion("Residencial 1 Familia/Casa de Empe")]
        U4SU59,
        [Descripcion("Residencial 1 Familia/Estanco, Sas")]
        U4SU60,
        [Descripcion("Residencial 1 Familia/Kindergarden")]
        U4SU61,
        [Descripcion("Residencial 1 Familia/Hotel")]
        U4SU62,
        [Descripcion("Residencial 1 Familia/Restaurante,")]
        U4SU63,
        [Descripcion("Residencial 1 Familia/Palenque")]
        U4SU64,
        [Descripcion("Residencial 1 Familia/Expendio, Bi")]
        U4SU65,
        [Descripcion("Residencial 1 Familia/Tienda, Bode")]
        U4SU66,
        [Descripcion("Residencial 1 Familia/Tienda, Bode")]
        U4SU67,
        [Descripcion("Residencial 1 Familia/Comedor")]
        U4SU68,
        [Descripcion("Residencial 1 Familia/Cantina y Go")]
        U4SU69,
        [Descripcion("Residencial 1 Familia/PulperÂ¡a y M")]
        U4SU70,
        [Descripcion("Residencial 1 Familia/Hotel y Nego")]
        U4SU71,
        [Descripcion("Residencial 1 Familia/ReposterÂ¡a")]
        U4SU72,
        [Descripcion("Residencial 1 Familia/Gasolinera")]
        U4SU73,
        [Descripcion("Residencial 1 Familia/Molino")]
        U4SU74,
        [Descripcion("Residencial 1 Familia/Autorepuesto")]
        U4SU75,
        [Descripcion("Residencial 1 Familia/Gimnacio")]
        U4SU76,
        [Descripcion("Residencial 1 Familia/Prostibulo o")]
        U4SU77,
        [Descripcion("Residencial 1 Familia/Vivero")]
        U4SU78,
        [Descripcion("Residencial 1 Familia/Taller MecÂ n")]
        U4SU79,
        [Descripcion("Residencial 1 Familia/Juegos Elect")]
        U4SU80,
        [Descripcion("Residencial 1 Familia/RelojerÂ¡a")]
        U4SU81,
        [Descripcion("Residencial 1 Familia/Centro Comer")]
        U4SU82,
        [Descripcion("Residencial 1 Familia/ZapaterÂ¡a")]
        U4SU83,
        [Descripcion("Residencial 1 Familia/Motel")]
        U4SU84,
        [Descripcion("Residencial 1 Familia/Taller de Ho")]
        U4SU85,
        [Descripcion("Residencial 1 Familia/Laboratorio ")]
        U4SU86,
        [Descripcion("")]
        U4SU87,
        [Descripcion("Residencial 1 Familia/SastrerÂ¡a")]
        U4SU88,
        [Descripcion("Residencial 1 Familia/DepÂ¢sitos")]
        U4SU89,
        [Descripcion("Residencial 1 Familia/PulperÂ¡a y C")]
        U4SU90,
        [Descripcion("Residencial 1 Familia/Buffete")]
        U4SU91,
        [Descripcion("Residencial 1 Familia/Almacen y Ci")]
        U4SU92,
        [Descripcion("Residencial 1 Familia/Taller de Co")]
        U4SU93,
        [Descripcion("Residencial 1 Familia/FloristerÂ¡a")]
        U4SU94,
        [Descripcion("Baldio")]
        U5SU0,
        [Descripcion("1 FAMILIA/FAB DE PINTURA ")]
        U5SU1,
        [Descripcion("1 FAMILIA/RESINERIA")]
        U5SU2,
        [Descripcion("1 FAMILIA/FAB DE HIELO")]
        U5SU3,
        [Descripcion("1 FAMILIA/FAB DE LADRILLO")]
        U5SU4,
        [Descripcion("1 FAMILIA/FAB DE EMBUTIDO")]
        U5SU5,
        [Descripcion("1 FAMILIA/FAB DE CALZADO ")]
        U5SU6,
        [Descripcion("1 FAMILIA/FAB DE MUEBLES ")]
        U5SU7,
        [Descripcion("Baldio")]
        U6SU0,
        [Descripcion("PulperÂ¡a/Fabrica de Ropa de NiÂ¤o")]
        U6SU1,
        [Descripcion("Centro Comercial/Fabrica")]
        U6SU2,
        [Descripcion("Baldio")]
        U7SU0,
        [Descripcion("Parque RecreaciÂ¢n Pasiva")]
        U7SU1,
        [Descripcion("Parque ZoolÂ¢gico")]
        U7SU2,
        [Descripcion("Campo de Futbol")]
        U7SU3,
        [Descripcion("Campo de Beisbol")]
        U7SU4,
        [Descripcion("Parque de RecreaciÂ¢n y Restaurante")]
        U7SU5,
        [Descripcion("BALNEARIO Y SALON DE BAILE  ")]
        U7SU6,
        [Descripcion("ESCUELAS")]
        U8SU10,
        [Descripcion("OTRAS EDIFICACIONES MUNICIPAL  ")]
        U8SU39,
        [Descripcion("BALDIO")]
        U8SU0,
        [Descripcion("EDIFICIO, PALACIO MUNICIPAL")]
        U8SU1,
        [Descripcion("ESCUELA MUNICIPAL")]
        U8SU2,
        [Descripcion("EMPRESA NACIONAL DE ENERGIA ELECTR")]
        U8SU3,
        [Descripcion("SANAA")]
        U8SU4,
        [Descripcion("HONDUTEL")]
        U8SU5,
        [Descripcion("FERROCARRIL NACIONAL")]
        U8SU6,
        [Descripcion("CUERPO DE BOMBEROS")]
        U8SU9,
        [Descripcion("CORREO NACIONAL")]
        U8SU7,
        [Descripcion("EMPRESA NACIONAL PORTUARIA")]
        U8SU8,
        [Descripcion("IGLESIAS")]
        U8SU11,
        [Descripcion("JUNTA NACIONAL DE BIENESTAR SOCIAL")]
        U8SU12,
        [Descripcion("PATRONATO PRO-MEJORAMIENTO COMUNAL")]
        U8SU13,
        [Descripcion("CEMENTERIO")]
        U8SU14,
        [Descripcion("CENTRO COMUNAL")]
        U8SU35,
        [Descripcion("REGISTRO NACIONAL DE LAS PERS  ")]
        U8SU36,
        [Descripcion("GRUPO ALCOHOLICOS ANONIMOS")]
        U8SU37,
        [Descripcion("D.I.M.A.C.H  ")]
        U8SU38,
        [Descripcion("CORTE SUPREMA DE JUSTICIA (C.S.J)")]
        U8SU40,
        [Descripcion("MINISTERIO DE HACIENDA Y CREDITO P")]
        U8SU41,
        [Descripcion("GOBERNACION")]
        U8SU22,
        [Descripcion("BANCO NACIONAL DE DESARROLLO AGRIC")]
        U8SU23,
        [Descripcion("TALLER DE ZAPATERIA")]
        U2SUD8,
        [Descripcion("COMEDOR")]
        U2SUD9,
        [Descripcion("HOSPITAL(PRIVADO)  ")]
        U2SUE1,
        [Descripcion("HOSPEDAJE, COMEDOR Y BILLARES  ")]
        U2SUE2,
        [Descripcion("GASOLIN,BODEGA, TALLER MEC  ")]
        U2SUE3,
        [Descripcion("VENTA DE LUBRICANTES  ")]
        U2SUE4,
        [Descripcion("TIENDA ")]
        U2SUE5,
        [Descripcion("VENTA DE BEBIDAS ALCOHOLICAS")]
        U2SUE6,
        [Descripcion("HOSPEDAJE Y COMEDOR")]
        U2SUE7,
        [Descripcion("VENTA DE POLLOS FRITOS Y ASAD  ")]
        U2SUE8,
        [Descripcion("JOYERIA Y BILLARES ")]
        U2SUE9,
        [Descripcion("TALLER DE REFRIGERACION  ")]
        U2SUF1,
        [Descripcion("APARTAM, EXPEN Y TAPICERIA  ")]
        U2SUF2,
        [Descripcion("HOJALATERIA  ")]
        U2SUF3,
        [Descripcion("BAR Y SALON DE BAILE  ")]
        U2SUF4,
        [Descripcion("DEPOSITO Y RETAURANTE ")]
        U2SUF5,
        [Descripcion("VENTA DE ROPA DE SEGUNDA ")]
        U2SUF6,
        [Descripcion("CASA DE EMPEÃ‘O  ")]
        U2SUF7,
        [Descripcion("TALLER DE ENGRANAJE Y LAVADO")]
        U2SUF8,
        [Descripcion("ABARROTERIA  ")]
        U2SUF9,
        [Descripcion("DEPOSITO O VENTA DE HIELO")]
        U2SUG1,
        [Descripcion("VENTA DE JUGO, REPOST Y TIEND  ")]
        U2SUG2,
        [Descripcion("CLINICA Y MERCADO  ")]
        U2SUG3,
        [Descripcion("BANCO Y FARMACIA")]
        U2SUG4,
        [Descripcion("TALLER MECANICO Y CENTRO COM")]
        U2SUG5,
        [Descripcion("LOTERIA DE CARTON  ")]
        U2SUG6,
        [Descripcion("HOTAL Y RESTAURANTE")]
        U2SUG7,
        [Descripcion("TALLER MECAN Y VENTA DE MADER  ")]
        U2SUG8,
        [Descripcion("CENTRO COMERC Y ACADEMIA BELL  ")]
        U2SUG9,
        [Descripcion("CARNICERIA Y ACADEMIA DE COST  ")]
        U2SUH1,
        [Descripcion("TALLER DE MOTO Y VTA DE REPUE  ")]
        U2SUH2,
        [Descripcion("OFICINA Y BODEGA")]
        U2SUH3,
        [Descripcion("GLORIETA  ")]
        U2SUH4,
        [Descripcion("TALLER DE BATERIAS ")]
        U2SUH5,
        [Descripcion("TALLER DE ENDEREZADO Y PINTUR  ")]
        U2SUH6,
        [Descripcion("HOTEL Y COMEDOR ")]
        U2SUH7,
        [Descripcion("TAPICERIA, MUEBLERIA Y MEREND  ")]
        U2SUH8,
        [Descripcion("HOTEL Y DISTRIB DE BICICLETAS  ")]
        U2SUH9,
        [Descripcion("PULPERIA Y BODEGA  ")]
        U2SUI1,
        [Descripcion("BLOQUERA  ")]
        U2SUI2,
        [Descripcion("CAR WASH  ")]
        U2SUI3,
        [Descripcion("REPOSTERIA Y PULPERIA ")]
        U2SUI4,
        [Descripcion("PARQUEO DE BUSES Y GLORIETA ")]
        U2SUI5,
        [Descripcion("BALNEARIO Y RESTAURANTE  ")]
        U2SUI6,
        [Descripcion("EMPACADORA DE CARNES  ")]
        U2SUI7,
        [Descripcion("PLANTA DE TRATAMIENTO ")]
        U2SUI8,
        [Descripcion("BODEGA, TALLER MEC Y REFRIGER  ")]
        U2SUI9,
        [Descripcion("FABRICA DE LAVANDEROS ")]
        U2SUJ1,
        [Descripcion("TALLER DE CARPINT. Y LLANTERA  ")]
        U2SUJ2,
        [Descripcion("TIENDA DE ACCES. PARA PIÃ‘ATAS  ")]
        U2SUJ3,
        [Descripcion("CAR WASH, VENTA DE LUB. Y GAS  ")]
        U2SUJ4,
        [Descripcion("BARBERIA Y SASTRERIA  ")]
        U2SUJ5,
        [Descripcion("REP DE RADIAD, LLANT Y GLORIE  ")]
        U2SUJ6,
        [Descripcion("GLORIETA Y LLANTERA")]
        U2SUJ7,
        [Descripcion("MERENDERO ")]
        U2SUJ8,
        [Descripcion("ASILO DE ANCIANOS  ")]
        U2SUJ9,
        [Descripcion("FARMACIA Y TIENDA  ")]
        U2SUK1,
        [Descripcion("VENTA DE NOVEDADES Y COSMET.")]
        U2SUK2,
        [Descripcion("PANADERIA Y VENTA DE AGUA PUR  ")]
        U2SUK3,
        [Descripcion("APARTAMENTO Y BARBERIA")]
        U2SUK4,
        [Descripcion("APARTAMENTO Y BAR  ")]
        U2SUK5,
        [Descripcion("APARTAMENTO  ")]
        U2SUK6,
        [Descripcion("VENTA DE REPUESTOS Y TALABART  ")]
        U2SUK7,
        [Descripcion("C. DENTAL, SALA  BELLEZA Y SA  ")]
        U2SUK8,
        [Descripcion("TALLER ELECTRICO")]
        U2SUK9,
        [Descripcion("EXPENDIO, VENTA DE REPUESTOS")]
        U2SUL1,
        [Descripcion("PULPERIA Y COMEDOR ")]
        U2SUL2,
        [Descripcion("CASA DE EMPEÃ‘O Y PULPERIA")]
        U2SUL3,
        [Descripcion("VENTA DE JUGOS Y LICUADOS")]
        U2SUL4,
        [Descripcion("APARTAMENTOS Y PULPERIA  ")]
        U2SUL5,
        [Descripcion("EXPENDIO Y PULPERIA")]
        U2SUL6,
        [Descripcion("APARTAMENTOS Y EXPENDIO  ")]
        U2SUL7,
        [Descripcion("KINDER Y ESC. PRIM(PRIVADA) ")]
        U2SUL8,
        [Descripcion("BARBERIA, ZAPATERIA Y RESTAUR  ")]
        U2SUL9,
        [Descripcion("EXPENDIO  ")]
        U2SUM1,
        [Descripcion("TALLER MECANICO Y EBANISTERIA  ")]
        U2SUM2,
        [Descripcion("VENTA DE GAS Y REP. DE AUTOS")]
        U2SUM3,
        [Descripcion("GUARDERIA(PRIVADA) ")]
        U2SUM4,
        [Descripcion("INTERNET(CYBERCAFE)")]
        U2SUM5,
        [Descripcion("FABRICA DE HERRERIA")]
        U3SUC2,
        [Descripcion("FABRICA DE TEJAS")]
        U3SUC3,
        [Descripcion("FAB, PLANIF. Y PURIF. DE AGUA  ")]
        U3SUC4,
        [Descripcion("FAB. DE CILINDROS Y BALCONES")]
        U3SUC5,
        [Descripcion("BENEFICIO DE CAFE  ")]
        U3SUC6,
        [Descripcion("FAB. Y BODEGA DE SAL Y CHILE")]
        U3SUC7,
        [Descripcion("TALLER DE ARTESANIA")]
        U3SUC8,
        [Descripcion("FAB. DE SECADO SOLAR DE MADER  ")]
        U3SUC9,
        [Descripcion("FABRICA DE CAMISETAS  ")]
        U3SUD1,
        [Descripcion("TALLER DE SOLDADURA")]
        U3SUD2,
        [Descripcion("GLORIETA Y TALLER DE BALCONER  ")]
        U3SUD3,
        [Descripcion("APARTAMENTOS Y FAB. DE BLOQUE  ")]
        U3SUD4,
        [Descripcion("FABRICA DE PRODUCTOS LACTEOS")]
        U3SUD5,
        [Descripcion("PLANTA PROCESADORA DE CITRICO  ")]
        U3SUD6,
        [Descripcion("PROCES. DE LECHE Y PORQUERIZA  ")]
        U3SUD7,
        [Descripcion("TALLER DE EBANISTERIA ")]
        U3SUD8,
        [Descripcion("PLANTA PROCESADORA DE BANANO")]
        U3SUD9,
        [Descripcion("1 FAMILIA/GRANJA AVICOLA ")]
        U4SU95,
        [Descripcion("1 FAMILIA/REP. DE LLANTAS")]
        U4SU96,
        [Descripcion("1 FAMILIA/TALLER EBANISTERIA")]
        U4SU97,
        [Descripcion("1 FAMILIA/PULP, BILLAR Y MOLI  ")]
        U4SU98,
        [Descripcion("1FAMILIA/TALABARTERIA ")]
        U4SU99,
        [Descripcion("1 FAMILIA/ESTABLO  ")]
        U4SUA1,
        [Descripcion("1 FAMILIA/TALLER ELECTRONICO")]
        U4SUA2,
        [Descripcion("1 FAM./TIENDA Y TALLER AUTO ")]
        U4SUA3,
        [Descripcion("1 FAM./TALLER REP. DE BATERIA  ")]
        U4SUA4,
        [Descripcion("1 FAMILIA/REPETIDORA DE RADIO  ")]
        U4SUA5,
        [Descripcion("1 FAM./PULPERIA Y ZAPATERIA ")]
        U4SUA6,
        [Descripcion("1 FAMILIA/PORQUERIZA  ")]
        U4SUA7,
        [Descripcion("1 FAM/COMERCIAL Y GRANJA AVIC  ")]
        U4SUA8,
        [Descripcion("1 FAMILIA/TERMINAL DE AUTOBUS  ")]
        U4SUA9,
        [Descripcion("1 FAMILIA/CINE  ")]
        U4SUB1,
        [Descripcion("1 FAM/FARMACIA SALA DE BELLEZ  ")]
        U4SUB2,
        [Descripcion("1 FAMILIA/VENTA DE HELADOS  ")]
        U4SUB3,
        [Descripcion("1 FAM/LAB. DENTAL Y ZAPATERIA  ")]
        U4SUB4,
        [Descripcion("1 FAM/FARMACIA Y SASTRERIA  ")]
        U4SUB5,
        [Descripcion("1 FAM/APARTAMENTOS  Y  TIENDA  ")]
        U4SUB6,
        [Descripcion("1 FAMILIA/VENTA DE CALZADO  ")]
        U4SUB7,
        [Descripcion("1 FAM/EXPENDIO, MOLINO Y PULP  ")]
        U4SUB8,
        [Descripcion("1 FAMILIA/TAPICERIA")]
        U4SUB9,
        [Descripcion("1 FAMILIA/VENTA DE PIÃ‘ATAS  ")]
        U4SUC1,
        [Descripcion("1 FAM/BAZAR, HOSP, S BELLEZA")]
        U4SUC2,
        [Descripcion("1 FAMILIA/VENTA DE LACTEOS  ")]
        U4SUC3,
        [Descripcion("1 FAM/CUART.  DIST. CONCENTR")]
        U4SUC4,
        [Descripcion("1FAM/COMER, TALLER RADIO Y TV  ")]
        U4SUC5,
        [Descripcion("1 FAM/SALA DE BELLEZA YBUFETE  ")]
        U4SUC6,
        [Descripcion("1 FAM/CARPINTERIA Y EXPENDIO")]
        U4SUC7,
        [Descripcion("1 FAM/VENTA DE GAS PROPANO  ")]
        U4SUC8,
        [Descripcion("1 FAM/TIENDA Y CASA DE EMPEÃ‘O  ")]
        U4SUC9,
        [Descripcion("1 FAM/AGENCIA, CAFET Y TIENDA  ")]
        U4SUD1,
        [Descripcion("1 FAM/CLINICA MEDICA Y FARMAC  ")]
        U4SUD2,
        [Descripcion("1 FAM/MOLINO Y TALLER ELECTRI  ")]
        U4SUD3,
        [Descripcion("1 FAMILIA/PULP Y CUARTERIA  ")]
        U4SUD4,
        [Descripcion("1 FAM/BAR, TALLER Y ZAPATERIA  ")]
        U4SUD5,
        [Descripcion("1FAM/EXPENDIO Y VIDEO JUEGOS")]
        U4SUD6,
        [Descripcion("1 FAM/PULPERIA Y DEPOSITO")]
        U4SUD7,
        [Descripcion("1 FAM/EXPENDIO Y VENTA DE REP  ")]
        U4SUD8,
        [Descripcion("1 FAM/APARTAMENTO Y BILLAR  ")]
        U4SUD9,
        [Descripcion("1 FAM/APART Y TALLER SASTRERI  ")]
        U4SUE1,
        [Descripcion("1 FAM/PULP Y TALLER BALCONERI  ")]
        U4SUE2,
        [Descripcion("1 FAMILIA/TALLER DE ARTESANIA  ")]
        U4SUE3,
        [Descripcion("1 FAM/TALLER REF. Y DEPOSITO")]
        U4SUE4,
        [Descripcion("1 FAMILIA/PULPERIA ")]
        U4SUE5,
        [Descripcion("1 FAM/TALLER DE BICICLETAS  ")]
        U4SUE6,
        [Descripcion("1 FAM/PULP Y JUEGOS DE VIDEO")]
        U4SUE7,
        [Descripcion("1 FAM/TALLER DE ARMAS DE FUEG  ")]
        U4SUE8,
        [Descripcion("1 FAMILIA/MUEBLERIA")]
        U4SUE9,
        [Descripcion("1 FAMILIA/BAR Y APARTAMENTOS")]
        U4SUF1,
        [Descripcion("1 FAM/TALLER ELECT AUTOMOTRIZ  ")]
        U4SUF2,
        [Descripcion("1 FAM/VENTA REP DE BICICLETAS  ")]
        U4SUF3,
        [Descripcion("1 FAM/SASTRERIA E IGLESIA")]
        U4SUF4,
        [Descripcion("1 FAMILIA/PULPERIA Y SATRERIA  ")]
        U4SUF5,
        [Descripcion("1 FAM/VENTA DE MATERIAL ELECT  ")]
        U4SUF6,
        [Descripcion("1 FAM/TALLER DE CARPINTERIA ")]
        U4SUF7,
        [Descripcion("1 FAMILIA/BAR Y MOLINO")]
        U4SUF8,
        [Descripcion("1 FAM/CASA DE EMPEÃ‘O Y BARBER  ")]
        U4SUF9,
        [Descripcion("1 FAM/TALLER DE RADIADORES  ")]
        U4SUG1,
        [Descripcion("1 FAM/DISTRIBUIDORA DE LLANTA  ")]
        U4SUG2,
        [Descripcion("1 FAMILIA/CLINICA Y LAVANDERI  ")]
        U4SUG3,
        [Descripcion("1 FAMILIA/VENTA DE ROPA  ")]
        U4SUG4,
        [Descripcion("1 FAM/TALLER MEC. Y EXPENDIO")]
        U4SUG5,
        [Descripcion("1 FAM/PULP. Y CLINICA ")]
        U4SUG6,
        [Descripcion("1 FAMILIA/TALLER DESOLDADURA")]
        U4SUG7,
        [Descripcion("1 FAM/TAL. MEC, LLANTERA Y PU  ")]
        U4SUG8,
        [Descripcion("1 FAM/OFIC. DE METEOROLOGIA ")]
        U4SUG9,
        [Descripcion("1 FAMILIA/VENTA DE ADORNOS  ")]
        U4SUH1,
        [Descripcion("1 FAM/FUNERARIA Y CAFETERIA ")]
        U4SUH2,
        [Descripcion("I FAM/TIENDA Y SASTRERIA ")]
        U4SUH3,
        [Descripcion("1 FAMILIA/BUFETE Y TIENDA")]
        U4SUH4,
        [Descripcion("1 FAM/PULP. Y APARTAMENTOS  ")]
        U4SUH5,
        [Descripcion("1 FAMILIA/HOSPEDAJE")]
        U4SUH6,
        [Descripcion("1 FAM/PULP Y DISCOTEQUE  ")]
        U4SUH7,
        [Descripcion("1 FAM/DISTRIB. AGROPECUARIA ")]
        U4SUH8,
        [Descripcion("1 FAM/TALLER MEC. Y SASTRERIA  ")]
        U4SUH9,
        [Descripcion("1 FAM/CAFETERIA Y DIST REPUES  ")]
        U4SUI1,
        [Descripcion("1 FAM/BODEGA, VENTA  ROPA USA  ")]
        U4SUI2,
        [Descripcion("1 FAM/BANCO, JUEGOS DE VIDEOS  ")]
        U4SUI3,
        [Descripcion("1 FAM/VENTA DE MAT DE COSTURA  ")]
        U4SUI4,
        [Descripcion("1 FAM/RELOJERIA, COM SASTRERI  ")]
        U4SUI5,
        [Descripcion("1 FAMILIA/EXPENDIO ")]
        U4SUI6,
        [Descripcion("1 FAM/MOLINO, PULP, J VIDEO G  ")]
        U4SUI7,
        [Descripcion("1 FAMILIA/APARTAMENTOS")]
        U4SUI8,
        [Descripcion("1 FAM/PULP, REP DE LLANTAS  ")]
        U4SUI9,
        [Descripcion("1 FAM/TAL DE HOJALATERIA, REP  ")]
        U4SUJ1,
        [Descripcion("1 FAMILIA/VENTA DE PINTURA  ")]
        U4SUJ2,
        [Descripcion("1 FAM/VENTA DE AGUA PURIFICAD  ")]
        U4SUJ3,
        [Descripcion("1 FAM/PULP, MOLINO, TALL Y CA  ")]
        U4SUJ4,
        [Descripcion("1 FAM/PULPERIA Y FUNERARIA  ")]
        U4SUJ5,
        [Descripcion("1 FAM/TALLER, VENTA REP MOTOC  ")]
        U4SUJ6,
        [Descripcion("1 FAMILIA/BANCO Y HOTEL  ")]
        U4SUJ7,
        [Descripcion("1 FAM/TIENDA Y FERRETERIA")]
        U4SUJ8,
        [Descripcion("1 FAM/PULP Y SALA DE BELLEZA")]
        U4SUJ9,
        [Descripcion("1 FAM/SALA BELLEZA Y SASTRERI  ")]
        U4SUK1,
        [Descripcion("1 FAM/PULPERIA Y BARBERIA")]
        U4SUK2,
        [Descripcion("1 FAM/PULPERIA Y EBANISTERIA")]
        U4SUK3,
        [Descripcion("1 FAMILIA/GLORIETA ")]
        U4SUK4,
        [Descripcion("1 FAM/EXPENDIO, PULP Y BILLAR  ")]
        U4SUK5,
        [Descripcion("1 FAMILIA/VENTA DE POLLOS")]
        U4SUK6,
        [Descripcion("1 FAM/VENTA DE REP. DE AUTOS")]
        U4SUK7,
        [Descripcion("INTERNET(CYBERCAFE)")]
        U4SUK8,
        [Descripcion("1 FAM / CONFITERIA ")]
        U5SU8,
        [Descripcion("1 FAM / TALLER DE BALCONE")]
        U5SU9,
        [Descripcion("1 FAM /CURTIEMBRE  ")]
        U5SU10,
        [Descripcion("1 FAM / FABRICA DE BLOQUES  ")]
        U5SU11,
        [Descripcion("1 FAM / TALLER MEC INDUSTRIAL  ")]
        U5SU12,
        [Descripcion("1 FAM / FABRICA DE JALEA ")]
        U5SU13,
        [Descripcion("1 FAM / FAB DE SOMBREROS ")]
        U5SU14,
        [Descripcion("1 FAM/ ASERRADERO  ")]
        U5SU15,
        [Descripcion("1 FAM/ TALLER DE HERRADERIA ")]
        U5SU16,
        [Descripcion("1 FAM/FAB COHETES Y PETARDOS")]
        U5SU17,
        [Descripcion("1 FAM/ FAB DE BATERIAS")]
        U5SU18,
        [Descripcion("1 FAM/FABRICA DE JUGOS")]
        U5SU19,
        [Descripcion("1 FAM/FABRICA DE TEJAS")]
        U5SU20,
        [Descripcion("1 FAM/ EBANISTERIA ")]
        U5SU21,
        [Descripcion("CANCHA DE BASKET BALL ")]
        U7SU7,
        [Descripcion("OTROS CENTROS DEPORTIVOS ")]
        U7SU8,
        [Descripcion("CLUB SOCIAL  ")]
        U7SU9,
        [Descripcion("PLAZA DE TOROS  ")]
        U7SU10,
        [Descripcion("PALENQUE  ")]
        U7SU11,
        [Descripcion("HIPODROMO ")]
        U7SU12,
        [Descripcion("COOPERATIVA  ")]
        U8SU15,
        [Descripcion("SINDICATO ")]
        U8SU16,
        [Descripcion("FEDERACION DE ASOC. FEMENINA")]
        U8SU17,
        [Descripcion("CLUB DE LEONES ROTARAC")]
        U8SU18,
        [Descripcion("CRUZ ROJA HONDUREÃ‘A")]
        U8SU19,
        [Descripcion("MINISTERIO DE EDUC. PUBLICA ")]
        U8SU20,
        [Descripcion("MINISTERIO DE SALUD PUBLICA ")]
        U8SU21,
        [Descripcion("POLICIA NACIONAL PREVENTIVA ")]
        U8SU24,
        [Descripcion("I.N.V.A")]
        U8SU25,
        [Descripcion("OTRAS INSTITUCIONES BENEFICAS  ")]
        U8SU26,
        [Descripcion("INT ANTROP E HISTORIA DE HOND  ")]
        U8SU27,
        [Descripcion("GRUPO CAMPESINO ")]
        U8SU28,
        [Descripcion("MINISTERIO DE REC NATURALES ")]
        U8SU29,
        [Descripcion("S.E.C.P.L.A.N")]
        U8SU30,
        [Descripcion("S.E.C.O.P.T  ")]
        U8SU31,
        [Descripcion("MERCADO MUNICIPAL  ")]
        U8SU32,
        [Descripcion("I.H.M.A")]
        U8SU33,
        [Descripcion("BANASUPRO ")]
        U8SU34,
        [Descripcion("RASTRO PUBLICO  ")]
        U8SU42,
        [Descripcion("INSTITUCIONES POLITICAS  ")]
        U8SU43,
        [Descripcion("D.G.P.P.M ")]
        U8SU44,
        [Descripcion("C.O.L.P.R.O.H.S.U.M.A ")]
        U8SU45,
        [Descripcion("I.M.P.R.E.M.A")]
        U8SU46,
        [Descripcion("F.F.A.A")]
        U8SU47,
        [Descripcion("TELEFONIA CELULAR  ")]
        U2SUM6,
        [Descripcion("GENERADORA DE ENERGIA ELECTRI  ")]
        U2SUM7,
        [Descripcion("CANTERA")]
        U2SUM8,
        [Descripcion("PRODUCCION DE ENERGIA ")]
        U3SUE2,
        [Descripcion("BALDIO ")]
        U9SU0,
        [Descripcion("EDIFICIO / PALACIO ")]
        U9SU1,
        [Descripcion("PARQUE ")]
        U9SU2,
        [Descripcion("ESCUELA")]
        U9SU3,
        [Descripcion("COLEGIO")]
        U9SU4,
        [Descripcion("MERCADO")]
        U9SU5,
        [Descripcion("CENTRO COMUNAL  ")]
        U9SU6,
        [Descripcion("CAMPO DE FUTBOL ")]
        U9SU7,
        [Descripcion("VIVERO ")]
        U9SU8,
        [Descripcion("CEMENTERIO")]
        U9SU9,
        [Descripcion("POZO")]
        U9SU10,
        [Descripcion("PREDIO BALDIO")]
        U10SU0,
        [Descripcion("HACIENDA DE GANADO-BOVINO")]
        U2SUM9,
        [Descripcion("BOMBA DE AGUA Y CANCHAS MULTI  ")]
        U9SU11,
        [Descripcion("TANQUES")]
        U9SU12,
        [Descripcion("HABITACIONAL ")]
        U9SU13,
        [Descripcion("KINDER ")]
        U9SU14,
        [Descripcion("IGLESIA")]
        U9SU15,
        [Descripcion("OFICINAS  DE AGUAS DE CHOLOMA  ")]
        U9SU16,
        [Descripcion("EDIFICIO DE OFICINAS MUNICIPA  ")]
        U9SU17,
        [Descripcion("CENTRO DE ALCANCE  ")]
        U9SU18,
        [Descripcion("ESTACION BOMBEROS  ")]
        U9SU19,
        [Descripcion("CENTRO COMERCIAL")]
        U9SU20,
        [Descripcion("BOTADERO DESECHO SOLIDOS ")]
        U9SU21,
        [Descripcion("CANCHA DE FUTBOL")]
        U8SU48,
        [Descripcion("CANCHAS CERCADAS")]
        U2SUO1,
        [Descripcion("BALDIO ")]
        U0SU0,
        [Descripcion("  CANCHA DE FUTBOL-FUTBOLITO  ")]
        U2SUD10,


    }


    public enum TIPO_EMPLEADO
    {
        ADMIN,
        NORMAL
    }

    public enum ESTATUS_TRIBUTARIO
    {
        ACTIVO,
        INACTIVO
    }

    public enum ESTADO_PREDIO
    {
        NO_PROCESADO = 0,
        PROCESANDO = 1,
        PROCESADO = 2
    }

}