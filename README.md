# Sparta_Dungeon
스파르타 던전 만들기 과제 (개인)

## 영상

- 이동

![이동점프점프대](https://github.com/user-attachments/assets/6d1f0e1b-32e1-4254-b2b7-4d0d0cf19a9e)
<br>
▷ 점프 / 점프대 이용 시 요구 스태미나가 부족하면 동작하지 않음

- 플레이어 HP

![HP](https://github.com/user-attachments/assets/a35b36a3-5e97-4a83-a75e-91b5cec7fc02)

- 오브젝트 설명 UI
  
![오브젝트설명](https://github.com/user-attachments/assets/35c65752-78c8-4bf8-81f1-1207cdca51b5)

- 속도
  
![속도](https://github.com/user-attachments/assets/cdc2f27d-1c52-4d90-a5e4-00ac11917e07)


- 움직이는 플랫폼

![플랫폼](https://github.com/user-attachments/assets/7c53ba0b-8ba3-4715-a67d-3c58df1742d8)

## 설치 방법
`git clone https://github.com/miju99/Sparta_Dungeon.git`
> Unity 2022.3.17f1 이상에서 테스트됨

## 사용 방법
* 키보드 WASD로 이동
* space 점프
* 마우스 왼쪽버튼 상호작용

## 필수 기능
### ①. 기본 이동 및 점프
  * 플레이어의 이동(WASD), 점프(Space) 설정
### ②. 체력바 UI
  * UI 캔버스에 체력바를 추가하고 플레이어의 체력을 나타내도록 설정. 플레이어의 체력이 변할 때마다 UI 갱신.
### ③. 동적 환경 조사
  * Raycast를 통해 플레이어가 조사하는 오브젝트의 정보를 UI에 표시.
  * 마우스 포인트 위치의 오브젝트의 이름, 설명 등을 화면에 표시
### ④. 점프대
  * 캐릭터가 밟을 때 위로 높이 튀어 오르는 점프대 구현
### ⑤. 아이템 데이터
  * 각 아이템의 이름, 설명, 속성 등을 ScriptableObject로 관리
### ⑥. 아이템 사용
  * 특정 아이템 사용 후 효과가 일정 시간 동안 지속되는 시스템 구현

## 도전 기능
### ①. 추가 UI
  * 점프 시 소모되는 스태미나를 표시하는 바 구현
### ②. 움직이는 플랫폼 구현
  * 시간에 따라 정해진 구역을 움직이는 발판 구현
  * 플레이어가 발판 위에서 이동할 때 자연스럽게 따라가도록 설정

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
