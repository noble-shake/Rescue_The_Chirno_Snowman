# Rescue The Chirno Snowman

Touhou GameJam 15 (2025) 출품작입니다.
눈덩이 속에 갇힌 치르노를 굴려 목표 지점까지 보내는 스테이지형 2D 물리 퍼즐입니다.

- 엔진: Unity 6 (6000.0.33f1)
- 개발 시기: 2025년 4월

## 원본 저장소

이 저장소는 공개용입니다. 에셋을 포함한 전체 프로젝트 원본은 비공개 저장소 `Rescue_The_Chirno_Snowman-Archive`에 따로 보관하고 있습니다.

원본에는 에셋 스토어에서 받은 팩과 그림·소리 리소스가 들어 있어 라이선스상 공개할 수 없습니다. 그래서 여기에는 **직접 작성한 코드만** 옮겼고, 이 저장소만 받아서는 프로젝트를 열어 실행할 수 없습니다.

## 빌드 다운로드

실행 파일은 이 저장소의 [Releases](https://github.com/noble-shake/Rescue_The_Chirno_Snowman/releases)에 올립니다.

현재는 준비 중이며, 올라오면 Releases 페이지에서 받을 수 있습니다.

## 폴더 구조

```
Rescue_The_Chirno_Snowman/
├── Assets/
│   └── Scripts/              게임 코드 전체
│       ├── PlayerFairy/      눈덩이(치르노) 상태와 커서 조작
│       ├── DialogSystem/     대화와 엔딩
│       ├── UI/               타이틀, 스테이지 선택, 옵션, 일시정지
│       ├── GameManager.cs, StageScriptableObject.cs
│       └── PipelineSystem.cs, GlassSystem.cs, GoalArea.cs 등 스테이지 기믹
├── Packages/manifest.json    사용한 Unity 패키지 목록
└── ProjectSettings/ProjectVersion.txt   엔진 버전
```

## 구현한 것

- **크기 기반 퍼즐**: 눈덩이가 일정 크기보다 작아야 지나갈 수 있는 파이프(`PipelineSystem`)와, 일정 크기 이상이어야 깨지는 유리(`GlassSystem`)
- **데이터 중심 스테이지**: 맵·클리어 조건·대사를 ScriptableObject(`StageScriptableObject`) 하나로 묶어, 코드를 고치지 않고 스테이지를 추가
- **대화 시스템**: 스탠딩 일러스트 다섯 자리를 쓰는 대화와 엔딩 연출(`DialogSystem/`)
- **게임 흐름**: 타이틀, 인트로, 스테이지, 엔딩 장면과 옵션·일시정지 화면(`UI/`)

## 사용한 외부 에셋 (미포함)

2D Ice World, Cartoon FX Remaster, Snow FX, 2D Platformer Snowy, Fantasy Skybox FREE
