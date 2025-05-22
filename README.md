# Sparta_Dungeon
스파르타 던전 만들기 과제 (개인)

## 영상

## 설치 방법
`git clone https://github.com/miju99/Sparta_Meta.git`
> Unity 2022.3.17f1 이상에서 테스트됨

## 사용 방법
* 키보드 WASD로 이동
* space 점프
* 마우스 왼쪽버튼 클릭

## 필수 기능
### ①. 기본 이동 및 점프
  * 플레이어의 이동(WASD), 점프(Space) 등을 설정
### ②. 체력바 UI
  * UI 캔버스에 체력바를 추가하고 플레이어의 체력을 나타내도록 설정. 플레이어의 체력이 변할 때마다 UI 갱신.
### ③. 동적 환경 조사
  * Raycast를 통해 플레이어가 조사하는 오브젝트의 정보를 UI에 표시.
  * 마우스 포인트의 위치의 오브젝트의 이름, 설명 등을 화면에 표시
### ④. 점프대
  * 캐릭터가 밟을 때 위로 높이 튀어 오르는 점프대 구현
### ⑤. 아이템 데이터
  * 각 아이템의 이름, 설명, 속성 등을 ScriptableObject로 관리
### ⑥. 아이템 사용
  * 특정 아이템 사용 후 효과가 일정 시간 동안 지속되는 시스템 구현

## 구현
| 기능 | 구현 위치 | 입력 처리 함수 / 방식 |
|-|-|-|
| 캐릭터 이동 | `Player.cs`| `Input.GetKey` (`WASD`) |
| 점프| `Player.cs` | `Input.GetKey(KeyCode.Space)` |
| 체력 / 스태미나 UI | `Player.cs` | `UpdateHpBar`, `UpdateSTBar`  |
| 장애물 충돌 데미지 | `SpikeObstacle.cs` | `OnCollisionStay` + `Time.time` |
| 아이템 상호작용 | `Interaction.cs` | `Raycast` + `Input.GetMouseButton(0)` |
| 버프 / 디버프 적용 | `Interaction.cs` | `Coroutine` + `ItemData.type` |
| 오브젝트 설명 UI | `Interaction.cs` | `TextMeshProUGUI` 제어 |
| 점프대 | `Player.cs` | `OnCollisionEnter` + `isJump` |
| 움직이는 플랫폼 | `MovingPlatform.cs`| `Vector3.MoveTowards` |
| 플랫 탑승 처리 | `Player.cs` | `transform.SetParent()` |
| 사운드 재생 | `Sound.cs` | `PlaySFX(string clipName)` |

## 기술 스택
  * 게임 엔진
    > Unity(Unity 2022.3.17f1)
  * 프로그래밍 언어
    > C#
