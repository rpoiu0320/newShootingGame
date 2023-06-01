using System.Collections.Generic;

//========================================
//##		������ ���� ObjectPool		##
//========================================
/*
    ������Ʈ Ǯ�� ���� :
    ���α׷� ������ ����ϰ� ��Ȱ��Ǵ� �ν��Ͻ����� ����&�������� �ʰ�
    �̸� �����س��� �ν��Ͻ����� ������ ��ü����(Ǯ)����
    �ν��Ͻ��� �뿩&�ݳ��ϴ� ������� ����ϴ� ���

    ���� :
    1. �ν��Ͻ����� ������ ��ü����(Ǯ)�� ����
    2. ���α׷��� ���۽� ��ü����(Ǯ)�� �ν��Ͻ����� �����Ͽ� ����
    3. �ν��Ͻ��� �ʿ�� �ϴ� ��Ȳ���� ��ü����(Ǯ)�� �ν��Ͻ��� �뿩�Ͽ� ���
    4. �ν��Ͻ��� �ʿ�� ���� �ʴ� ��Ȳ���� ��ü����(Ǯ)�� �ν��Ͻ��� �ݳ��Ͽ� ����    

    ���� :
    1. ����ϰ� ����ϴ� �ν��Ͻ��� ������ �ҿ�Ǵ� ������带 ����
    2. ����ϰ� ����ϴ� �ν��Ͻ��� ������ ������ �ݷ��� �δ��� ����

    ���� :
    1. �̸� �����س��� �ν��Ͻ��� ���� ������� �ʴ� ��쿡�� �޸𸮸� �����ϰ� ����
    2. �޸𸮰� �˳����� ���� ��⿡�� �ʹ� ���� ������Ʈ Ǯ���� ����ϴ� ���,
       �������� ���������� �پ��� ������ ���α׷��� �δ��� �Ǵ� ��찡 ����
*/

namespace DesingPattern
{
    public class ObjectPooler
    {
        private Stack<PooledObject> objectPool = new Stack<PooledObject>();
        private int poolSize = 100;

        public void CreatePool()
        {
            for (int i = 0; i < poolSize; i++)
            {
                objectPool.Push(new PooledObject());
            }
        }

        public PooledObject GetPool()
        {
            if (objectPool.Count > 0)
                return objectPool.Pop();
            else
                return new PooledObject();
        }

        public void ReturnPool(PooledObject pooled)
        {
            objectPool.Push(pooled);
        }

        public class PooledObject
        {
            // ����&������ ����� Ŭ����
        }
    }
}