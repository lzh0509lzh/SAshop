//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading;
//using System.Web;

//namespace SaAPI.Context
//{
//    public class MemoryCache
//    {
//        private readonly ITraceableLog _logger;

//        private readonly TimeSpan memoryCleanInterval = TimeSpan.FromMinutes(30);

//        private static MemoryCache instance = null;
//        private static readonly MemoryCache noLogInstance = new MemoryCache(new MockLog());
//        private static object _lock = new object();

//        public static MemoryCache Instance
//        {
//            get
//            {
//                if (instance == null)
//                {
//                    lock (_lock)
//                    {
//                        if (instance == null)
//                        {
//                            instance = new MemoryCache();
//                        }
//                    }
//                }

//                return instance;
//            }
//        }

//        public static MemoryCache NoLogInstance
//        {
//            get { return noLogInstance; }
//        }

//        private readonly ReaderWriterLockSlim cacheLock = new ReaderWriterLockSlim();

//        private IDictionary<string, CacheItem> keyDataMappings =
//            new Dictionary<string, CacheItem>(StringComparer.OrdinalIgnoreCase);

//        public bool TrySetData(string key, object data, TimeSpan timeout)
//        {
//            return TrySetData(key, data, null, timeout);
//        }

//        public bool TrySetData(string key, object data, string metaData, TimeSpan timeout)
//        {
//            cacheLock.EnterWriteLock();

//            try
//            {
//                CacheItem cacheItem;
//                if (this.keyDataMappings.TryGetValue(key, out cacheItem))
//                {
//                    cacheItem.Data = data;
//                    cacheItem.MetaData = metaData;
//                }
//                else
//                {
//                    cacheItem = new CacheItem
//                    {
//                        Key = key,
//                        Data = data,
//                        MetaData = metaData,
//                    };

//                    this.keyDataMappings.Add(key, cacheItem);
//                }

//                cacheItem.LastUpdateUtc = cacheItem.LastAccessUtc = DateTime.UtcNow;
//                cacheItem.ExpireUtc = timeout == TimeSpan.MaxValue ? DateTime.MaxValue : DateTime.UtcNow + timeout;
//                return true;
//            }
//            catch (Exception e)
//            {
//                _logger.Error("fail to set data", e);
//            }
//            finally
//            {
//                cacheLock.ExitWriteLock();
//            }

//            return false;
//        }

//        public bool TryGetData(string key, out CacheItem cacheItem)
//        {
//            var success = false;
//            cacheItem = null;

//            if (string.IsNullOrEmpty(key))
//            {
//                return false;
//            }

//            cacheLock.EnterReadLock();
//            try
//            {
//                success = this.keyDataMappings.TryGetValue(key, out cacheItem);
//            }
//            catch (Exception e)
//            {
//                _logger.Error("fail to get data", e);
//            }
//            finally
//            {
//                cacheLock.ExitReadLock();
//            }

//            if (success)
//            {
//                if (cacheItem != null && cacheItem.ExpireUtc > DateTime.UtcNow)
//                {
//                    cacheItem.LastAccessUtc = DateTime.UtcNow;
//                    return true;
//                }
//                else
//                {
//                    _logger.Debug("MemoryCache expired for " + key);
//                    DeleteKey(key);
//                    return false;
//                }
//            }
//            else
//            {
//                _logger.Debug("MemoryCache missing for " + key);
//            }

//            return false;
//        }

//        public object GetData(string key)
//        {
//            CacheItem cacheItem;
//            if (TryGetData(key, out cacheItem) && cacheItem != null)
//            {
//                return cacheItem.Data;
//            }

//            return null;
//        }

//        public T GetData<T>(string key)
//        {
//            CacheItem cacheItem;
//            if (TryGetData(key, out cacheItem))
//            {
//                try
//                {
//                    return (T)cacheItem.Data;
//                }
//                catch (InvalidCastException)
//                {
//                    return default(T);
//                }
//            }

//            return default(T);
//        }

//        public bool DeleteKey(string key)
//        {
//            cacheLock.EnterWriteLock();
//            try
//            {
//                return this.keyDataMappings.Remove(key);
//            }
//            catch (Exception e)
//            {
//                _logger.Error("fail to delete key", e);
//            }
//            finally
//            {
//                cacheLock.ExitWriteLock();
//            }

//            return false;
//        }

//        private void Clean()
//        {
//            try
//            {

//                var keys = this.keyDataMappings.Keys.ToList();
//                foreach (var key in keys)
//                {
//                    CacheItem cacheItem;
//                    TryGetData(key, out cacheItem);
//                }

//                GC.Collect();

//            }
//            catch (Exception e)
//            {
//                _logger.Error("fail to clean data", e);
//            }
//        }

//        private readonly Timer _timer;

//        private MemoryCache()
//        {
//            _logger = CustomLogManager.GetTraceableLog(MethodBase.GetCurrentMethod().DeclaringType);
//            _timer = new Timer(_ => Clean(), null, memoryCleanInterval, memoryCleanInterval);
//        }

//        public MemoryCache(ITraceableLog logger)
//        {
//            _timer = new Timer(_ => Clean(), null, memoryCleanInterval, memoryCleanInterval);
//            _logger = logger;
//        }

//        public void Dispose()
//        {
//            cacheLock.Dispose();
//            _timer.Dispose();
//        }


//        public bool TrySetHashSetData(string key, string hashKey, object data, TimeSpan timeout)
//        {
//            return this.TrySetData(key + ":" + hashKey, data, timeout);
//        }

//        public bool TryGetHashSetData(string key, string hashKey, out CacheItem cacheItem)
//        {
//            return TryGetData(key + ":" + hashKey, out cacheItem);
//        }
//    }
//}