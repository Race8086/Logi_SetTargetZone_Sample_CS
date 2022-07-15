using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LedCSharp;

namespace Logi_SetTargetZone_Sample_CS
{

    /**
     * 15/07/2022 Programa para porbar el api de logitech con el teclado G213
     * Se ha utilizado el ejemplo suministrado por el fabricante, eliminando el código
     * no referido al dispositivo
     * 
     * */
    public class Program
    {
        static void Main(string[] args)
        {
            int a;
            Console.WriteLine("Inicio de la depuración");
            // Initialize the LED SDK
            //bool LedInitialized = LogitechGSDK.LogiLedInitWithName("SetTargetZone Sample C#");
            bool LedInitialized = LogitechGSDK.LogiLedInit();
            if (!LedInitialized)
            {
                Console.WriteLine("LogitechGSDK.LogiLedInit() failed.");
                return;
            }

            Console.WriteLine("LED SDK Initialized");
            Console.WriteLine("Press \"ENTER\" to continue...");
            Console.ReadLine();
            LogitechGSDK.LogiLedSetTargetDevice(LogitechGSDK.LOGI_DEVICETYPE_ALL);
            //La línea anterior inicializa cualquier disposito Logitech incluido en el API y conectado a la máquina.
            // Set all devices to Black
            LogitechGSDK.LogiLedSetLighting(0, 0, 0); // Aunque la función de inicialización apaga las zonas se utiliza
            // este comnando de nuevo.
            // ** prueba de la función de Zona ( la zona 0 es todo el teclado
            // G213 tiene 5 zonas adicionales, no se pueden direccionar teclas individuales
            // Set G213 keyboard zones to Red, Yellow, Green, Cyan, Blue
            LogitechGSDK.LogiLedSetLightingForTargetZone(DeviceType.Keyboard, 1, 100, 100, 100);
            LogitechGSDK.LogiLedSetLightingForTargetZone(DeviceType.Keyboard, 2, 100, 100, 100);
            LogitechGSDK.LogiLedSetLightingForTargetZone(DeviceType.Keyboard, 3, 100, 100, 100);
            LogitechGSDK.LogiLedSetLightingForTargetZone(DeviceType.Keyboard, 4, 100, 0, 0);
            LogitechGSDK.LogiLedSetLightingForTargetZone(DeviceType.Keyboard, 5, 0, 100, 0);

            // Test Efects on G213 keyboard

            

            Console.WriteLine("Press \"ENTER\" to exit...");
            Console.ReadLine();

            Console.WriteLine("LED SDK Shutting down");
            LogitechGSDK.LogiLedShutdown();
        }
    }
}
