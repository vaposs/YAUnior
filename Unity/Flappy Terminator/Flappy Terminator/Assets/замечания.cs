/*
------ИСПРАВЛЕННО
1 - public event Action<Bullet> onHit;
    события называем в прошедшем времени, Hitted можно, или Bumped, но наверное первое,
    хоть и не по правилам английского
    А Обработчики событий уже через союз On Именуются
    Bullet.Hit += OnHit; Наверное так можно, не уверен насчет глагола Hit, как-то не нравится мне он.
    Суть одна, событие просто в прошедшем, обработчик события On + имя события


-------Через дженерики
2 - public class BulletPool : MonoBehaviour
    public class EnemyBulletPool : MonoBehaviour
    public class ObjectPool : MonoBehaviour
    дубляж в этих классах


------ИСПРАВЛЕННО
3 - public class Enemy : MonoBehaviour
    public event Action<Enemy> onDestroyed;
    Та же проблема с именем события, и с большой буквы пишем


------ИСПРАВЛЕННО
4 - public class PlayerMove : MonoBehaviour
    if(collision.gameObject.TryGetComponent(out EnemyBullet enemyBullet) ||
    collision.gameObject.TryGetComponent(out GameOverZone gameOverZone) ||
    collision.gameObject.TryGetComponent(out Enemy enemy))
    Унаследуй наверное от одного класса и одну проверку сделай на общий базовый класс


------ИСПРАВЛЕННО
5 - public class Shooting : MonoBehaviour 
    if (Input.GetKeyDown(KeyCode.C))
    Выделяй переменную для кнопки и дай ей имя, ShootKey например
*/