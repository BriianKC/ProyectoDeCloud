using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace PELICULAS.UAPI
{
    public class CRUD <T>
    {
        public T[] Select(string Url)
        {
            try
            {
                using (var api = new WebClient())
                {
                    api.Headers.Add("Content-Type", "application/json");
                    var json = api.DownloadString(Url);
                    var data = Newtonsoft.Json.JsonConvert.DeserializeObject<T[]>(json);
                    return data;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Ha sucedido un error inesperado (" + ex.Message + ")");
            }
        }
        public T Select_ById (string Url, string id) 
        {
            try
            {
                using (var api = new WebClient())
                {
                    api.Headers.Add("Content-type", "application/json");
                    var json = api.DownloadString(Url + "/" + id);
                    var data = Newtonsoft.Json.JsonConvert.DeserializeObject<T>(json);
                    return data;
                }

            }
            catch (Exception ex)
            {
                throw new Exception("Ha sucedido un errror inesperado (" + ex.Message + ")");
            }

        }

        public void update (string Url, string Id,T data) 
        {
            try
            {
                using (var api = new WebClient())
                {
                    api.Headers.Add("Content-type", "application/json");
                    var json = Newtonsoft.Json.JsonConvert.SerializeObject(data);
                    api.UploadString(Url + "/" + Id, "PUT", json);
                }

            }
            catch (Exception ex)
            {
                throw new Exception("Ha sucedido un errror inesperado (" + ex.Message + ")");
            }
           
        }

        public T insert(String Url,T data) 
        {
            try
            {
                using (var api = new WebClient())
                {
                    api.Headers.Add("Content-type", "application/json");
                    var json = Newtonsoft.Json.JsonConvert.SerializeObject(data);
                    json = api.UploadString(Url, "POST", json);
                    data = Newtonsoft.Json.JsonConvert.DeserializeObject<T>(json);
                    return data;
                }

            }
            catch (Exception ex)
            {
                throw new Exception("Ha sucedido un errror inesperado (" + ex.Message + ")");
            }
            
        }

        public void delete (string Url, string Id)
        {
            try
            {
                using (var api = new WebClient())
                {
                    api.Headers.Add("Content-type", "application/json");
                    api.UploadString(Url + "/" + Id, "DELETE", "");

                }

            }
            catch (Exception ex)
            {
                throw new Exception("Ha sucedido un errror inesperado (" + ex.Message + ")");
            }
           
        }
    }
}
