using System;
using System.Collections.Generic;
using System.Text;

namespace RestApp.Common.Responses
{
    public class RestaurantResponse
    {
        public int Id { get; set; }
      
        public string Name { get; set; }

        public string Description { get; set; }

        public Guid ImageId { get; set; }

        public string ImageFullPath => ImageId == Guid.Empty
            ? $"https://onsalecarmona.azurewebsites.net/images/noimage.png"
            : $"https://programaciondistribuida.blob.core.windows.net/categories/{ImageId}";

    }
}
