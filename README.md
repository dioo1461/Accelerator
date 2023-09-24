# Accelerator
유니티 기반 FPS 에임 연습 및 사용자간 대전 프로그램 (미완성)

# 기술 스택
- Unity

# 인게임

![main](https://github.com/dioo1461/Accelerator/assets/73684109/4f9c00ab-484c-4c85-aadc-7c62f4b210ae)
▲ Accuracy: 총 명중률, Weapon: 현재 선택한 무기, Weap_Cool: 선택한 무기의 남은 쿨다운(연사 간격)

![rifle](https://github.com/dioo1461/Accelerator/assets/73684109/00db05fa-2b0f-424e-abbb-13cd0ca41995)
▲ 무기-Rifle: 연사 간격이 빠른 히트스캔 무기, tracking 에임

![railgun](https://github.com/dioo1461/Accelerator/assets/73684109/7efe5b64-eda6-4f8e-b152-07349859c4dc)
▲ 무기-Railgun: 연사 간격이 느린 히트스캔 무기, flick 에임

![revoler](https://github.com/dioo1461/Accelerator/assets/73684109/2e7c6db6-e7ab-4ad1-9f7a-cf79b5419920)
▲ 무기-Revolver: 연사 간격이 적당한 히트스캔 무기, flick 에임

![target_moving](https://github.com/dioo1461/Accelerator/assets/73684109/9bdd379b-7ca2-4417-b629-b856b640fecc)
▲ 타깃에는 일정량의 hp가 있으며, 타깃이 처치되거나 처치되지 않은 채 일정 시간(target_lifetime)이 지나면 일정 크기(target_size)로 새로운 위치에 재생성됨.

![angle-explanation](https://github.com/dioo1461/Accelerator/assets/73684109/0de04edf-d7b6-4a9d-8337-9417dc3d1bf0)

▲ 새로 생성되는 타깃은, 이전에 처치된 타깃이 있던 지점(빨간 점)으로부터 Θ값(target_spawn_angle)을 더한 각도 내에 랜덤으로 생성됨. (그림에서 노란색으로 표시된, 반구 표면의 원형 지점 내부에 랜덤 생성)

target_lifetime, target_size, target_spawn_angle 은 플레이어의 현재 accuracy에 따라 변동됨(난이도 조정).

# Notion 개발 기록 (22년 11월 - 22년 1월)
https://www.notion.so/jaesion/Accelerator-5250cad1c4ae4b3c8adfce6cea937aa1?pvs=4

