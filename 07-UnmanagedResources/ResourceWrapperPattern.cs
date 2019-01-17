using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Haken.UnmanagedResources
{

	// http://knowledge-base.havit.cz/2006/11/11/idisposable-resourcewrapper-design-pattern/

	public class ResourceWrapperPattern : IDisposable
	{
		// Indikuje, zdali byl objekt již uklizen.
		private bool disposed = false;

		/// <summary>
		/// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
		/// </summary>
		public void Dispose()
		{
			Dispose(true);
			GC.SuppressFinalize(this); // chceme se odebrat z Finalization Queue a ušetřit náklady finalizace
		}

		/// <summary>
		/// Implementační private-metoda.
		/// </summary>
		/// <param name="disposing">rozlišuje, zdali je voláno z Dispose (pak true), nebo Finalize (pak false).</param>
		protected virtual void Dispose(bool disposing)
		{
			// Dispose() má být imunní vůči vícenásobnému volání
			if (!this.disposed)
			{
				// Pokud jsme volání z metody Dispose(),
				// můžeme uvolnit i vlastněné IDisposable prvky. Z destruktoru ne.
				if (disposing)
				{
					// Uvolňujeme tedy tzv. managed resources.
					// component.Dispose();
				}

				// ...v každém případě však uvolňujeme unmanaged resources 
				// CloseHandle(handle);
				// handle = IntPtr.Zero;
				disposed = true;
			}
		}

		/// <summary>
		/// Ochrana před jelity. Pokud někdo nezavolá Dispose, resp. nepoužije using, pak se z toho chceme vyhrabat.
		/// </summary>
		~ResourceWrapperPattern()
		{
			Dispose(false);
		}

		/// <summary>
		/// Běžné funkční metody chráníme, aby nebyly volány nad disposed objektem.
		/// </summary>
		public void DoSomething()
		{
			if (disposed)
			{
				throw new ObjectDisposedException("Taky jelito.");
			}

			// následuje vlastní funkčnost metody

		}
	}
}
